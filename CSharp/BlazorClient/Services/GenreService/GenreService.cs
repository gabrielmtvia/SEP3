using System.Text.Json;
using ModelClasses;
using JsonNamingPolicy = System.Text.Json.JsonNamingPolicy;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace BlazorClient.Services.GenreService;

public class GenreService : IGenreService
{
    private readonly HttpClient _httpClient;

    public GenreService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public List<Genre> Genres { get; set; } = new List<Genre>();
    
    public async Task GetGenresAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Genre>>>("/Genre");
        if (response != null && response.Data != null)
            Genres = response.Data;
    }

    public async Task AddGenreAsync(Genre genreToAdd)
    {
        await _httpClient.PostAsJsonAsync("/Genre", genreToAdd);
    }

    public async Task DeleteGenreAsync(string type)
    {
        await _httpClient.DeleteAsync($"/Genre/{type}");
    }

    public async Task<List<Genre>> GetAllGenresAsync()
    {
        var result = await _httpClient.GetAsync("/Genre");
        if (result.IsSuccessStatusCode)
        {
            var readAsStringAsync = await result.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<List<Genre>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        return null;
    }
}