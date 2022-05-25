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
        Console.WriteLine("khale   " +book.Isbn+", "+book.ImageUrl);
       var result= await _httpClient.PostAsJsonAsync("/Book", book);
       Console.WriteLine(result.ToString());
    
    }

    public async Task GetBooksAsync(string? genreUrl = null)
    {
        // var result = genreUrl == null ? 
        //     await _httpClient.GetFromJsonAsync<List<Book>>>("/Book") :
        //     await _httpClient.GetFromJsonAsync<ServiceResponse<List<Book>>>($"/Book/genre/{genreUrl}");
        var result = await _httpClient.GetFromJsonAsync<List<Book>> ("/Book");
        if(result!=null) 
            Books = result;
        
        BooksChanged.Invoke();
    }
    
    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var result = await _httpClient.GetFromJsonAsync<Book>($"/Book/{isbn}");
        return result;
    }

    

    public async Task SearchBooks(string searchText)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Book>>>($"/Book/search/{searchText}");

        if (result != null && result.Data != null)
        {
            Books = result.Data;
        }

        if (Books.Count == 0)
        {
            Message = "No books found";
        }
        
        BooksChanged.Invoke();
    }

    public async Task<List<string>> GetBookSearchSuggestionsAsync(string searchText)
    {
        var result =
            await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"/Book/searchSuggestions/{searchText}");
        Console.WriteLine(result.Message);
        return result.Data;
    }
    
}