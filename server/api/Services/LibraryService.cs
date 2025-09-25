using System.ComponentModel.DataAnnotations;
using api.Controllers;
using api.Dtos;
using efscaffold;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class LibraryService(MyDbContext dbContext) : ILibraryService
{
    public async Task<List<BookDto>> GetAllBooks()
    {
        return await dbContext.Books.Select(b => new BookDto(b)).ToListAsync();
    }

    public async Task<BookDto> CreateBook(CreateBookDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
       var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Pages = dto.Pages,
            Createdat = DateTime.UtcNow,
        };
        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync();
        return new BookDto(book);
    }

    public async Task<BookDto?> UpdateBook(UpdateBookDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        var existingBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id == dto.Id);
        if (existingBook == null)
        {
            return null;
        }

        existingBook.Title = dto.Title;
        existingBook.Pages = dto.Pages;
        await dbContext.SaveChangesAsync();
        return new  BookDto(existingBook);
    }

    public async Task<BookDto?> DeleteBook(string id)
    {
        var existingBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (existingBook == null)
        {
            return null;
        }
        dbContext.Books.Remove(existingBook);
        await dbContext.SaveChangesAsync();
        return new  BookDto(existingBook);
    }

    public async Task<List<AuthorDto>> GetAllAuthors()
    {
        return await dbContext.Authors.Select(a => new AuthorDto(a)).ToListAsync();
    }

    public async Task<AuthorDto> CreateAuthor(CreateAuthorDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        var author = new Author()
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name,
            Createdat = DateTime.UtcNow,
        };
        dbContext.Authors.Add(author);
        await dbContext.SaveChangesAsync();
        return new  AuthorDto(author);
    }

    public async Task<AuthorDto?> UpdateAuthor(UpdateAuthorDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto), true);
        var existingAuthor = await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == dto.Id);
        if (existingAuthor == null)
        {
            return null;
        }

        existingAuthor.Name = dto.Name;
        await dbContext.SaveChangesAsync();
        return new AuthorDto(existingAuthor);
    }
    
}