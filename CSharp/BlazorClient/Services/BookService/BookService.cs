using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.Net.Http.Headers;
using ModelClasses;


namespace BlazorClient.Services.BookService;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    
    

    public string Message { get; set; } = "Loading books...";
    public event Action BooksChanged;
    public List<Book> Books { get; set; } = new List<Book>();

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
  
    
    

    public async Task AddBookAsync(Book book)
    {
        await _httpClient.PostAsJsonAsync("/Book", book);
    }

    public async Task GetBooksAsync(string? genreUrl = null)
    {
        var genre = String.Empty;
        
        if (genreUrl != null)
        {
            genre = genreUrl.Replace('-', ' ');
        }
        
        var result = genre.Equals(string.Empty) ? 
             await _httpClient.GetFromJsonAsync<List<Book>>("/Book") :
             await _httpClient.GetFromJsonAsync<List<Book>>($"/Book/genre/{genre}");
        
        if(result!=null) 
            Books = result;
        
        BooksChanged.Invoke();
    }
    
    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var result = await _httpClient.GetFromJsonAsync<Book>($"/Book/{isbn}");
        return result;
    }

    

    public async Task SearchBooksByAuthor(string searchText)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Book>>($"/Book/author/{searchText}");

        if (result != null)
        {
            Books = result;
        }

        if (Books.Count == 0)
        {
            Message = "No books found";
        }
        
        BooksChanged.Invoke();
    }
    
    public async Task SearchBooksByTitle(string searchText)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Book>>($"/Book/title/{searchText}");

        if (result != null)
        {
            Books = result;
        }

        if (Books.Count == 0)
        {
            Message = "No books found";
        }
        
        BooksChanged.Invoke();
    }

    
    public async Task<List<Book>> GetAllBooksAsync()
    {
        var result = await _httpClient.GetAsync("/Book");
        if (result.IsSuccessStatusCode)
        {
            var readAsStringAsync = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Book>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        return null;
    }
    
    public async Task DeleteBookAsync(string isbn)
    {
        await _httpClient.DeleteAsync($"/Book/{isbn}");
    }

}