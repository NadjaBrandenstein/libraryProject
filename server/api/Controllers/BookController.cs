using efscaffold;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class BookController(MyDbContext dbContext) : ControllerBase
{
    [Route(nameof(GetAllBooks))]
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        var books = dbContext.Books.ToList();
        return books;
    }

    [Route(nameof(CreateBook))]
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook ([FromBody] CreateBookDto dto)
    {
        /*var result = await BookService.CreateBook(dto);
        return result;*/

        var myBook = new Book()
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Pages = dto.Pages
        };
        dbContext.Books.Add(myBook);
        await dbContext.SaveChangesAsync();
        return  myBook;
    }
    
}