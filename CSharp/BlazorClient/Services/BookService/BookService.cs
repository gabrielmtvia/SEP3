using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Shared;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BlazorClient.Services.BookService;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    

    public async Task AddBookAsync(Book book)
    {
        await _httpClient.PostAsJsonAsync("/Book", book);
    }

    public async Task DeleteBookAsync(string isbn)
    {
        await _httpClient.DeleteAsync($"/Book/{isbn}");
    }

    public async Task EditBook(Book bookToEdit)
    {
        await _httpClient.PutAsJsonAsync("/Book", bookToEdit);
    }

    public async Task<List<Book>>GetAllBooksAsync()
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

    public async Task<Book> GetBookByIsbnAsync(string isbn)
    {
        var result = await _httpClient.GetFromJsonAsync<Book>($"/Book/{isbn}");
        return result;
    }

    public async Task<List<Book>> GetBooksByNameAsync(string searchName)
    {
        var result = await _httpClient.GetAsync($"/Book/search/{searchName}");

        if (result.IsSuccessStatusCode)
        {
            var readAsStringAsync = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Book>>(readAsStringAsync);
        }

        return null;
    }
    

    /*
    public async Task<List<string>> GetBookSearchSuggestionsAsync(string searchText)
    {
        var result =
            await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"/Book/searchSuggestions/{searchText}");
        Console.WriteLine(result.Message);
        return result.Data;
    } */
}