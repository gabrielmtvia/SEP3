using ModelClasses;

namespace BlazorClient.Services.BookService;

public interface IBookService
{
    event Action BooksChanged;
    public List<Book> Books { get; set; }
    Task GetBooksAsync(string? categoryUrl = null);
    Task<ServiceResponse<Book>> GetBookAsync(long isbn);
}