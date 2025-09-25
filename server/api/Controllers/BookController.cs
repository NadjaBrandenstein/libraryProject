using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class BookController(ILibraryService libraryService) : ControllerBase
{
    [HttpGet(nameof(GetAllBooks))]
    public async Task<ActionResult<List<BookDto>>> GetAllBooks()
    {
        var books = await libraryService.GetAllBooks();
        return Ok(books);
    }
    
    [HttpPost(nameof(CreateBook))]
    public async Task<ActionResult<BookDto>> CreateBook ([FromBody] CreateBookDto dto)
    {
        var result = await libraryService.CreateBook(dto);
        return CreatedAtAction(nameof(GetAllBooks), new  { Id = result.Id }, result);
    }
    
    [HttpPatch(nameof(UpdateBook))]
    public async Task<ActionResult<BookDto>> UpdateBook([FromBody] UpdateBookDto dto)
    {
        var result = await libraryService.UpdateBook(dto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpDelete(nameof(DeleteBook))]
    public async Task<ActionResult<BookDto>> DeleteBook(string id)
    {
        var result = await libraryService.DeleteBook(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
}