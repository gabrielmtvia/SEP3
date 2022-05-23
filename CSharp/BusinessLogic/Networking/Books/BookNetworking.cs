using System.Text.Json;
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
      /*  var serialize = JsonSerializer.Serialize(book);
        var bookMessage = new BookMessage
        {
            Book = serialize
        };

        var addBook = client.addBook(bookMessage);

        Console.WriteLine(addBook.Book);*/
      await client.createBookAsync(new BookMessage
      {
          Isbn = book.Isbn,Author = book.Author,Description = book.Description,Edition = book.Edition
          ,Price = book.Price,Title = book.Title,Url = book.ImageUrl
      });
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

    
}