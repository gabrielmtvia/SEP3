namespace BlazorClient.Services.BookService;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public event Action BooksChanged;
    public List<Book> Books { get; set; } = new List<Book>();

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task GetBooksAsync(string? categoryUrl = null)
    {
        var result = categoryUrl == null ? 
            await _httpClient.GetFromJsonAsync<ServiceResponse<List<Book>>>("/Book") :
            await _httpClient.GetFromJsonAsync<ServiceResponse<List<Book>>>($"/Book/category/{categoryUrl}");
        if(result!=null && result.Data !=null) 
            Books = result.Data;
        
        BooksChanged.Invoke();
    }
    
    public async Task<ServiceResponse<Book>> GetBookAsync(long isbn)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Book>>($"/Book/{isbn}");
        return result;
    }
}