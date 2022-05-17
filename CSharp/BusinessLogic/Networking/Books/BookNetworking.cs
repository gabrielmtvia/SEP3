using System.Text.Json;

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
        var serialize = JsonSerializer.Serialize(book);
        var bookMessage = new BookMessage
        {
            Book = serialize
        };

        var addBook = client.addBook(bookMessage);

        Console.WriteLine(addBook.Book);
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        throw new NotImplementedException();
    }
}