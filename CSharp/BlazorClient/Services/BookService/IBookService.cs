using ModelClasses;

namespace BlazorClient.Services.BookService;

public interface IBookService
{
    Task<List<Book>> GetBooks();
}