using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class UpdateAuthorDto
{
    public string Id { get; set; } = null!;
    
    [MinLength(1)] 
    [Required] 
    public required string Name { get; set; } = null!;
}