namespace BusinessLogicServer.Networking.Genres;

public interface IGenreNetworking
{
    Task AddGenreAsync(Genre genre);
    Task<List<Genre>> GetAllGenreAsync();
    Task DeleteGenreAsync(string type);
}