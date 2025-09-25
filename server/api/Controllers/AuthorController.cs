using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AuthorController(ILibraryService libraryService) : ControllerBase
{
    [HttpGet(nameof(GetAllAuthors))]
    public async Task<ActionResult<AuthorDto>> GetAllAuthors(AuthorDto dto)
    {
        var authors = await libraryService.GetAllAuthors();
        return Ok(authors);
    }

    [HttpPost(nameof(CreateAuthor))]
    public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] CreateAuthorDto dto)
    {
        var result = await libraryService.CreateAuthor(dto);
        return CreatedAtAction(nameof(GetAllAuthors), new { Id = result.Id }, result);
    }

    [HttpPatch(nameof(UpdateAuthor))]
    public async Task<ActionResult<AuthorDto>> UpdateAuthor([FromBody] UpdateAuthorDto dto)
    {
        var result = await libraryService.UpdateAuthor(dto);
        return Ok(result);
    }
}