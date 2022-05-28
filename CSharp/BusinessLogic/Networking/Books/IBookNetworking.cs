using ModelClasses;

namespace BusinessLogicServer.Networking.Books;

public interface IBookNetworking
{
     Task AddBookAsync(Book book);
     Task<Book> GetBookByIsbnAsync(string isbn);

     Task<List<Book>> GetAllBookAsync();

     Task<List<Book>> GetBookByGenreAsync(string genre);

     Task<List<Book>> GetBookByTitleAsync(string title);

     Task<List<Book>> GetBookByAuthorAsync(string author);

     Task DeleteBookByIsbn(string isbn);



}