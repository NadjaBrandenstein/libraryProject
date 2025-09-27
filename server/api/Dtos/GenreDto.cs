using efscaffold;

namespace api.Controllers;

public class GenreDto
{
    public GenreDto(Genre genre)
    {
        Id = genre.Id;
        Name = genre.Name;
        Createdat = genre.Createdat;
        Books = genre.Books?.Select(b => b.Id).ToList() ?? new List<string>();
    }
    
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? Createdat { get; set; }
    
    public List<String> Books { get; set; } = new();
}