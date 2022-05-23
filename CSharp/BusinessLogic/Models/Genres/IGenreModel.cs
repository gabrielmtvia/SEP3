namespace BusinessLogicServer.Models.Genres;

public interface IGenreModel
{
    Task AddGenreAsync(Genre genre);
    Task<List<Genre>> GetAllGenresAsync();
    Task DeleteGenreAsync( String type);
}