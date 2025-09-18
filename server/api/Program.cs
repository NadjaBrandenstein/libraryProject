using efscaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpgsql();
});

var app = builder.Build();

app.MapGet("/", ([FromServices] MyDbContext dbContext) =>
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
