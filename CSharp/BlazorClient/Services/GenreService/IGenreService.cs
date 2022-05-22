using ModelClasses;

namespace BlazorClient.Services.GenreService;

public interface IGenreService
{
    Task AddGenreAsync(Genre genreToAdd);
    Task <List<Genre>> GetAllGenresAsync();
   
}