﻿using System.ComponentModel.DataAnnotations;
using api.Dtos;
using efscaffold;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class BookService(MyDbContext dbContext) : ILibraryService<BookDto, CreateBookDto, UpdateBookDto>
{
    public async Task<List<BookDto>> GetAll()
    {
        return await dbContext.Books.Select(b => new BookDto(b)).ToListAsync();
    }
    
    public async Task<BookDto> Create(CreateBookDto dto)
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

    public async Task<BookDto?> Update(UpdateBookDto dto)
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
        return new BookDto(existingBook);
    }

    public async Task<BookDto?> Delete(string id)
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
    
}