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
          //  Genres = new List<Genre>();
        }

        public Book(string isbn, string title, string author, string edition, string description, string imageUrl, double price)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Edition = edition;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
        }


        public override string ToString()
        {
            return $"Title - {Title}, Author - {Author}, Price - {Price}, Description - {Description}, Edition - {Edition}, Genres - {Genres}, ISBN - {Isbn}, ImageUrl - {ImageUrl}";
        }
    }


 
   
 
    
   
    
    

   