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
        
        await bookNetworking.AddBookAsync(book);
        
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
       return await bookNetworking.GetAllBookAsync();
    }

    public async Task<Book> GetBookByIsbn(String isbn)
    {
        var result = await bookNetworking.GetBookByIsbnAsync(isbn);
      return result;
    }

    public async Task<List<Book>> GetBookByGenreAsync(string genre)
    {
        return await  bookNetworking.GetBookByGenreAsync(genre);
    }

    public async Task<List<Book>> GetBookByTitleAsync(string title)
    {
        return await bookNetworking.GetBookByTitleAsync(title);
    }

    public async Task<List<Book>> GetBookByAuthorAsync(string author)
    {
        return await bookNetworking.GetBookByAuthorAsync(author);
    }

    public async Task DeleteBookByIsbn(string isbn)
    {
        await bookNetworking.DeleteBookByIsbn(isbn);
    }
}