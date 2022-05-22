using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorClient.Services.BookService;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    
    

    public string Message { get; set; } = "Loading books...";
    public event Action BooksChanged;
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Book> AllBooks { get; set; }

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    

    public async Task AddBookAsync(Book book)
    {
        await _httpClient.PostAsJsonAsync("/Book", book);
    }


    public async Task<List<Book>>GetAllBooksAsync()
    {
        var result = await _httpClient.GetAsync("/Book");
        if (result.IsSuccessStatusCode)
        {
            var readAsStringAsync = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Book>>(readAsStringAsync);
        }
        return null;
    }
    
    
    // public async Task GetBooksAsync(string? genreUrl = null)
    // {
    //     var result = genreUrl == null ? 
    //         await _httpClient.GetFromJsonAsync<ActionResult<List<Book>>>("/Book") :
    //         await _httpClient.GetFromJsonAsync<ActionResult<List<Book>>>($"/Book/genre/{genreUrl}");
    //     if(result!=null && result.Data !=null) 
    //         Books = result.Data;
    //     
    //     BooksChanged.Invoke();
    // }
    
    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var result = await _httpClient.GetFromJsonAsync<Book>($"/Book/{isbn}");
        return result;
    }

    public async Task SearchBooks(string searchText)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Book>>>($"/Book/search/{searchText}");

        if (result is {Data: { }})
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
            await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"/BookToAdd/searchSuggestions/{searchText}");
        return result.Data;
    }
}