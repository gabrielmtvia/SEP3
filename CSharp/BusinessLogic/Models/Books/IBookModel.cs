using BusinessLogicServer.Networking.Books;
using ModelClasses;

namespace BusinessLogicServer.Models.Books;

public interface IBookModel
{
    
    public Task AddBookAsync(Book book);
    public Task<List<Book>> GetAllBooksAsync();
    public Task<Book> GetBookByIsbnAsync(string isbn);


}