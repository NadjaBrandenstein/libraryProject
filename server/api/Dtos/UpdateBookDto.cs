using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class UpdateBookDto
{
    public string Id { get; set; } = null!;
    [Range(1, int.MaxValue)] 
    public int Pages { get; set; }
    [MinLength(1)] 
    public string Title { get; set; }
}