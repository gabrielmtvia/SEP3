using System.Text.Json;
using BlazorClient.Services.BookService;


namespace BusinessLogicServer.Networking.Books;

public class BookNetworking : IBookNetworking
{
    private BookGrpcService.BookGrpcServiceClient client;
    
    
    public BookNetworking(BookGrpcService.BookGrpcServiceClient client)
    {
        this.client = client;
    }

    public async Task AddBookAsync(Book book)
    {
        var buildBookMessage = book.BuildBookMessage();
        var addBook = await client.addBookAsync(buildBookMessage);
    }

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var requestMessage = new BookByIsbn()
        {
            Isbn = isbn
        };

        // make the response message and give the request message as param to the rpc call
        var response = client.getBookByIsbn(requestMessage);
        if (String.IsNullOrEmpty(response.Isbn))
        {
            return null;
        }

        return new Book(response);
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