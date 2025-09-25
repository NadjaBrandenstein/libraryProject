using api.Controllers;
using api.Dtos;
using efscaffold;

namespace api.Services;

public interface ILibraryService
{
    Task<List<BookDto>> GetAllBooks();
    Task<BookDto> CreateBook (CreateBookDto dto);
    Task<BookDto> UpdateBook(UpdateBookDto dto);
    Task<BookDto> DeleteBook(string id);
    
    Task<List<AuthorDto>> GetAllAuthors();
    Task<AuthorDto> CreateAuthor(CreateAuthorDto dto);
    Task<AuthorDto> UpdateAuthor(UpdateAuthorDto dto);
}