using BusinessLogicServer.Networking.Books;
using ModelClasses;

namespace BusinessLogicServer.Models.Books;

public interface IBookModel
{
    
    public Task AddBookAsync(Book book);
    public Task<List<Book>> GetAllBooksAsync();
    public Task<Book> GetBookByIsbn(string isbn);
    
    public Task<List<Book>> GetBookByGenreAsync(string genre);
     
    public Task<List<Book>> GetBookByTitleAsync(string title);
     
    public Task<List<Book>> GetBookByAuthorAsync(string author);

    public Task DeleteBookByIsbn(string isbn);
}