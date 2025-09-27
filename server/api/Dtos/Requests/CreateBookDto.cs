using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public record CreateBookDto
{
    [Range(1, int.MaxValue)] 
    [Required] 
    public int Pages { get; set; } 
    
    [MinLength(1)] 
    [Required] 
    public required string Title { get; set; }
}