using ModelClasses;

namespace BlazorClient.Services.BookService;

public interface IBookService
{
    public string Message { get; set; }
    event Action BooksChanged;
    public List<Book> Books { get; set; }
    Task GetBooksAsync(string? categoryUrl = null);
    Task<ServiceResponse<Book>> GetBookAsync(long isbn);

    Task SearchBooks(string searchText);
    Task<List<string>> GetBookSearchSuggestionsAsync(string searchText);
}