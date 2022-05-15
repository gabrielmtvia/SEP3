using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    public string Isbn { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Edition { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public List<Genre> Genres { get; set; }

    public Book()
    {
        Genres = new List<Genre>();
    }

    public override string ToString()
    {
        return $"Title - {Title}, Author - {Author}, Price - {Price}";
    }
}