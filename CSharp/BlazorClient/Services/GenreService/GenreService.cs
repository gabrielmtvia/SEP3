using Newtonsoft.Json;

namespace BlazorClient.Services.CategoryService;

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

    public Task AddGenreAsync(Genre genreToAdd)
    {
        return _httpClient.PostAsJsonAsync("/Genre",genreToAdd);
        
    }


    public async Task<List<Genre>> GetAllGenresAsync()
    {
        var result = await _httpClient.GetAsync("/Genre");
        if (result.IsSuccessStatusCode)
        {
            /*
                        var readAsStringAsync = await result.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<List<Genre>>(readAsStringAsync);
            */
        }

        return null;
    }
}