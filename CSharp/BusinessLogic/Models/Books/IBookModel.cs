using BusinessLogicServer.Networking.Books;

namespace BusinessLogicServer.Models.Books;

public interface IBookModel
{
    
    public Task AddBookAsync(Book book);
    public Task<List<Book>> GetAllBooksAsync();
    public Task<Book> GetBookByIsbn(string isbn);


}