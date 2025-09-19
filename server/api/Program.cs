using api;
using efscaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Services.AddAppOptions(builder.Configuration);

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpgsql(appOptions.DbConnectionString);
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(config => config
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .SetIsOriginAllowed(x => true));

app.MapGet("/", (
    [FromServices] IOptions<AppOptions> options,
    [FromServices] MyDbContext dbContext) =>
{
    var myBooks = new Book()
    {
        Id = Guid.NewGuid().ToString(),
        Title = "test",
        Pages = 150
    };
    dbContext.Books.Add(myBooks);
    dbContext.SaveChanges();
    
    var books = dbContext.Books.ToList();
    return books;
    
});

app.Run();
