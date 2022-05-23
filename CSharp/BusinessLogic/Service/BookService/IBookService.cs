using ModelClasses;

namespace BusinessLogicServer.Service.BookService;

public interface IBookService
{
    Task<ServiceResponse<List<Book>>> GetAllBooksAsync();
    Task<ServiceResponse<Book>> GetBookByIsbnAsync(string isbn);
    Task<ServiceResponse<List<Book>>> GetBooksByGenreAsync(string genreUrl);
    Task<ServiceResponse<List<Book>>> SearchBooksAsync(string searchText);
    Task<ServiceResponse<List<string>>> GetBookSearchSuggestionsAsync(string searchText);
}