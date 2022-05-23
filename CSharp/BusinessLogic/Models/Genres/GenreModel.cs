using BusinessLogicServer.Networking.Genres;

namespace BusinessLogicServer.Models.Genres;

public class GenreModel : IGenreModel
{

    private IGenreNetworking genreNetworking;

    public GenreModel(IGenreNetworking genreNetworking)
    {
        this.genreNetworking = genreNetworking;
    }
    
    
    
    public async Task AddGenreAsync(Genre genre)
    {
       await genreNetworking.AddGenreAsync(genre);
    }

    public async Task<List<Genre>> GetAllGenresAsync()
    {
       return await genreNetworking.GetAllGenreAsync();
    }

    public Task DeleteGenreAsync(String type)
    {
       return genreNetworking.DeleteGenreAsync(type);
    }
}