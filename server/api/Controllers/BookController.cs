using api.Dtos;
using api.Services;
using efscaffold;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class BookController(ILibraryService libraryService) : ControllerBase
{
    [Route(nameof(GetAllBooks))]
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAllBooks()
    {
        var books = await libraryService.GetAllBooks();
        return books;
    }

    [Route(nameof(CreateBook))]
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook ([FromBody] CreateBookDto dto)
    {
        var result = await libraryService.CreateBook(dto);
        return result;
    }
    
}