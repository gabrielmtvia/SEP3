using BusinessLogicServer.Networking.Books;
using ModelClasses;

namespace BusinessLogicServer.Models.Books;

public class BookModel : IBookModel
{

    private IBookNetworking bookNetworking;

    public BookModel(IBookNetworking bookNetworking)
    {
        this.bookNetworking = bookNetworking;
    }
    
    
    
    
    // validation for: if ISBN already exists in the Database first
    public async Task AddBookAsync(Book book)
    {
        var bookByIsbnAsync = await GetBookByIsbnAsync(book.Isbn);
        if (bookByIsbnAsync == null)
        {
            await bookNetworking.AddBookAsync(book); 
        }

    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
       return await bookNetworking.GetAllBookAsync();
    }

    public async Task<Book> GetBookByIsbnAsync(String isbn)
    {
        var result = await bookNetworking.GetBookByIsbnAsync(isbn);
        return result;
    }
}