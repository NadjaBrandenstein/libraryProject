using api.Dtos;
using efscaffold;

namespace api.Services;

public interface ILibraryService
{
    Task<BookDto> CreateBook (CreateBookDto dto);
    Task<List<BookDto>> GetAllBooks();
    Task<BookDto> UpdateBook(UpdateBookDto dto);
    Task<BookDto> DeleteBook(string id);
}