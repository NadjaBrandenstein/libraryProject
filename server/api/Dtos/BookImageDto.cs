using efscaffold;

namespace api.Dtos;

public class BookImageDto
{
    public BookImageDto(Bookimage bookimage)
    {
        Id = bookimage.Id;
        Bookid = bookimage.Bookid;
        Url = bookimage.Url;
        Createdat = bookimage.Createdat;
        Book = bookimage.Book;
    }
    
    public string Id { get; set; } = null!;

    public string? Bookid { get; set; }

    public string Url { get; set; } = null!;

    public DateTime? Createdat { get; set; }

    public virtual Book? Book { get; set; }
}