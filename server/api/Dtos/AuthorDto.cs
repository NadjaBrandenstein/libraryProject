using efscaffold;

namespace api.Controllers;

public class AuthorDto
{
    public AuthorDto(Author author)
    {
        Id = author.Id;
        Name = author.Name;
        Createdat = author.Createdat;
        BookIds = author.Books?.Select(a => a.Id).ToList() ?? new List<string>();
    }
    
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? Createdat { get; set; }
    
    public List<string> BookIds { get; set; } = null!;
}