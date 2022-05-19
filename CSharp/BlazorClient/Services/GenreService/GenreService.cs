using ModelClasses;

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
}