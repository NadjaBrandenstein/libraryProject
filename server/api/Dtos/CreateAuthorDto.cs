using System.ComponentModel.DataAnnotations;

namespace api.Controllers;

public class CreateAuthorDto
{
    [MinLength(1)] 
    public string Name { get; set; } = null!;
}