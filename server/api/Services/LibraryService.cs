using System.ComponentModel.DataAnnotations;
using api.Dtos;
using efscaffold;

namespace api.Services;

public class LibraryService(MyDbContext dbContext) : ILibraryService
{
    public async Task<List<Book>> GetAllBooks()
    {
        return dbContext.Books.ToList();
    }

    public async Task<Book> CreateBook(CreateBookDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);

        var myBook = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Pages = dto.Pages
        };
        dbContext.Books.Add(myBook);
        dbContext.SaveChanges();
        return myBook;
    }
}