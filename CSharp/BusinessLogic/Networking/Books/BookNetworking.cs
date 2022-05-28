using System.Text.Json;
using Google.Protobuf;
using ModelClasses;


namespace BusinessLogicServer.Networking.Books;

public class BookNetworking : IBookNetworking
{
    private BookService.BookServiceClient client;
    
    
      public BookNetworking(BookService.BookServiceClient client)
    {
        this.client = client;
    }



      public async Task AddBookAsync(Book book)
      {

          var bookProto = await client.getBookByIsbnAsync(new BookIsbnMessage
          {
              Isbn = book.Isbn
          });
          
          if (bookProto.Isbn.Equals("-*/01234InBs56789-*/"))
          {
              Console.WriteLine("NO ISBN EXISTS");
          


          bool hasGenre = true;
          foreach (ModelClasses.Genre g in book.Genres)
          {
              if (g.Name == "NoGenre")
                  hasGenre = false;
          }


          if (hasGenre == false)
          {
              await client.createBookAsync(new BookMessage
              {
                  Isbn = book.Isbn, Author = book.Author, Description = book.Description, Edition = book.Edition,
                  Price = book.Price, Title = book.Title, Url = book.ImageUrl
              });
          }
          else
          {
              var GenresProto = new List<GenreBookMessage>();
              foreach (ModelClasses.Genre genre in book.Genres)
              {
                  var genreProto = new GenreBookMessage();
                  genreProto.Type = genre.Name;
                  GenresProto.Add(genreProto);
              }

              client.createBookWithGenres(new BookGenreMessage
              {
                  Book = new BookMessage
                  {
                      Author = book.Author, Description = book.Description, Edition = book.Edition, Isbn = book.Isbn,
                      Price = book.Price, Title = book.Title, Url = book.ImageUrl
                  },
                  Genres =
                  {
                      GenresProto.ToArray()
                  }

              });

          }

      }
}

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {

        var bookProto = await client.getBookByIsbnAsync(new BookIsbnMessage
        {
            Isbn = isbn
        });
        Book book = new Book(bookProto.Isbn, bookProto.Title, bookProto.Author, bookProto.Edition, bookProto.Description,
            bookProto.Url, bookProto.Price);
        



        return book;

    }
    

    public async Task<List<Book>> GetAllBookAsync()
    {
        var  books = new List<Book>();
        var allBooksAsync = await client.getAllBooksAsync(new EmptyBookMessage());
        var bookMessage = allBooksAsync.Books;
        foreach (var bookProto in bookMessage)
        {
            var book = new Book
            {
                Isbn = bookProto.Isbn,
                Title = bookProto.Title,
                Author = bookProto.Author,
                Description = bookProto.Description,
                Edition = bookProto.Edition,
                ImageUrl = bookProto.Url,
                Price = bookProto.Price

            };
            books.Add(book);

        }

        
        return books;
    }

    public async Task<List<Book>> GetBookByGenreAsync(string genre)
    {
        var  books = new List<Book>();
        var allBooksAsync = await client.getAllBooksByGenreAsync(new GenreBookMessage
        {
            Type = genre
        });
        var bookMessage = allBooksAsync.Books;
        foreach (var bookProto in bookMessage)
        {
            var book = new Book
            {
                Isbn = bookProto.Isbn,
                Title = bookProto.Title,
                Author = bookProto.Author,
                Description = bookProto.Description,
                Edition = bookProto.Edition,
                ImageUrl = bookProto.Url,
                Price = bookProto.Price

            };
            books.Add(book);

        }

        
        return books;
    }

    public async Task<List<Book>> GetBookByTitleAsync(string title)
    {
        var  books = new List<Book>();
        var allBooksAsync = await client.getAllBooksByTitleAsync(new GenreBookMessage
        {
            Type = title
        });
        var bookMessage = allBooksAsync.Books;
        foreach (var bookProto in bookMessage)
        {
            var book = new Book
            {
                Isbn = bookProto.Isbn,
                Title = bookProto.Title,
                Author = bookProto.Author,
                Description = bookProto.Description,
                Edition = bookProto.Edition,
                ImageUrl = bookProto.Url,
                Price = bookProto.Price

            };
            books.Add(book);

        }

        
        return books;
    }

    public async Task<List<Book>> GetBookByAuthorAsync(string author)
    {
        var  books = new List<Book>();
        var allBooksAsync = await client.getAllBooksByAuthorAsync(new GenreBookMessage
        {
            Type = author
        });
        var bookMessage = allBooksAsync.Books;
        foreach (var bookProto in bookMessage)
        {
            var book = new Book
            {
                Isbn = bookProto.Isbn,
                Title = bookProto.Title,
                Author = bookProto.Author,
                Description = bookProto.Description,
                Edition = bookProto.Edition,
                ImageUrl = bookProto.Url,
                Price = bookProto.Price

            };
            books.Add(book);

        }

        
        return books;
    }

    public async Task DeleteBookByIsbn(string isbn)
    {
        await client.deleteBookAsync(new BookIsbnMessage
        {
            Isbn = isbn
        });
        
       
    }
}