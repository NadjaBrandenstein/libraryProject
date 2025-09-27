using System.ComponentModel.DataAnnotations;

namespace api.Controllers;

public class CreateAuthorDto
{
    [MinLength(1)] 
    [Required]
    public required string Name { get; set; } = null!;
}