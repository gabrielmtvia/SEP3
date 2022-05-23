using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
namespace ModelClasses;

    public class Book
    {
    
        [Required]
        [StringLength(13, ErrorMessage = "ISBN number must be 13 digits")]
        public string Isbn { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Book title is too long.")]
        public string Title { get; set; } 
        [Required]
        [StringLength(200, ErrorMessage = "Author name is too long.")]
        public string Author { get; set; }
        [StringLength(200, ErrorMessage = "Edition name is too long.")]
        public string Edition { get; set; } 
        [Required]
        [StringLength(500, ErrorMessage = "Book description title is too long.")]
        public string Description { get; set; } 
        public string ImageUrl { get; set; } 
        //  [Required, Range(1, 300)]
        //  [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
       // [Required]
        public List<Genre> Genres { get; set; }

    public Book()
    {
    }

    public Book(BookMessage book)
    {
        Isbn = book.Isbn;
        Title = book.Title;
        Author = book.Author;
        Edition = book.Edition;
        Description = book.Description;
        ImageUrl = book.ImageUrl;
        Price = book.Price;
        Genres = Genre.FromListMessageToGenreList(book.Genres);
    }

    public BookMessage BuildBookMessage()
    {
        return new BookMessage
        {
            Isbn = this.Isbn,
            Author = this.Author,
            Description = this.Description,
            Edition = this.Edition,
            Genres = Genre.BuildListGenreMessage(this.Genres),
            ImageUrl = this.ImageUrl,
            Price = this.Price,
            Title = this.Title
        };
    }

    public override string ToString()
    {
        return
            $"Title - {Title}, Author - {Author}, Price - {Price}, Description - {Description}, Edition - {Edition}, Genres - {Genres}, ISBN - {Isbn}, ImageUrl - {ImageUrl}";
    }
}