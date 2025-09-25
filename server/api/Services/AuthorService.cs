using System.ComponentModel.DataAnnotations;
using api.Controllers;
using api.Dtos;
using efscaffold;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class AuthorService(MyDbContext dbContext) : ILibraryService<AuthorDto, CreateAuthorDto, UpdateAuthorDto>
{
    public async Task<List<AuthorDto>> GetAll()
    {
        return await dbContext.Authors.Select(a => new AuthorDto(a)).ToListAsync();
    }

    public async Task<AuthorDto> Create(CreateAuthorDto dto)
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

    public async Task<AuthorDto?> Update(UpdateAuthorDto dto)
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

    public async Task<AuthorDto?> Delete(string id)
    {
        var existingAuthor = await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        if (existingAuthor == null)
        {
            return null;
        }

        dbContext.Authors.Remove(existingAuthor);
        return new AuthorDto(existingAuthor);
    }
}