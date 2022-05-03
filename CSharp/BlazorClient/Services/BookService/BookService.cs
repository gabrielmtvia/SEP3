using ModelClasses;

namespace BlazorClient.Services.BookService;

public class BookService : IBookService
{
    private readonly HttpClient httpClient;

    public BookService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<List<Book>> GetBooks()
    {
        return await httpClient.GetFromJsonAsync<List<Book>>("/Book");
    }
}