namespace BlazorClient.Services.CategoryService;

public interface IGenreService
{
    Task AddGenreAsync(Genre genreToAdd);
    Task <List<Genre>> GetAllGenresAsync();
   
}