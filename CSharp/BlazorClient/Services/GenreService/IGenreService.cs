using ModelClasses;

namespace BlazorClient.Services.GenreService;

public interface IGenreService
{
    List<Genre> Genres { get; set; }
    Task GetGenresAsync();
    Task AddGenreAsync(Genre genreToAdd);
    Task DeleteGenreAsync(string type);
    Task<List<Genre>> GetAllGenresAsync();
}