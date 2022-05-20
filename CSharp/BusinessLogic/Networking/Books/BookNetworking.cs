using System.Text.Json;
using ModelClasses;

namespace BusinessLogicServer.Networking.Books;

public class BookNetworking : IBookNetworking
{
    private BookService.BookServiceClient _bookServiceClient;
    
    
      public BookNetworking(BookService.BookServiceClient client)
    {
        this._bookServiceClient = client;
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
      await _bookServiceClient.createBookAsync(new BookMessage
      {
          Isbn = book.Isbn,Author = book.Author,Description = book.Description,Edition = book.Edition
          ,Price = book.Price,Title = book.Title,Url = book.ImageUrl
      });
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> GetAllBooks()
    {  
        //var book = new Book();
        var  books = new List<Book>();
        var allBooksAsync = await _bookServiceClient.getAllBooksAsync(new EmptyBookMessage());
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