using api.Dtos;
using efscaffold;

namespace api.Services;

public interface ILibraryService
{
    Task<Book> CreateBook (CreateBookDto dto);
    Task<List<Book>> GetAllBooks();
}