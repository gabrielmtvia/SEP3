using ModelClasses;

namespace BlazorClient.Services.GenreService;

public interface IGenreService
{
    List<Genre> Genres { get; set; }
    Task GetGenresAsync();
}