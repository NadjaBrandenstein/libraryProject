using System.ComponentModel.DataAnnotations;

namespace api.Controllers;

public class CreateGenreDto
{
    [MinLength(1)]
    [Required] 
    public required string Name { get; set; }
}