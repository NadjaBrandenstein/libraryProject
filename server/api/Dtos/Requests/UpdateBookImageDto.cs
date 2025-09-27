using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class UpdateBookImageDto
{
    [Required]
    public  required string Id { get; set; }
    
    [MinLength(1)]
    [Required] 
    public required string Url { get; set; }
}