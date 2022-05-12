namespace BlazorClient.Services.CategoryService;

public interface IGenreService
{
    List<Genre> Genres { get; set; }
    Task GetGenresAsync();
}