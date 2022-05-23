using BusinessLogicServer.Networking.Genre;

namespace BusinessLogicServer.Models.Genre;

public class GenreModel:IGenreModel
{
    private IgenreNetworking _genreNetworking;

    public GenreModel(IgenreNetworking genreNetworking)
    {
        _genreNetworking = genreNetworking;
    }
    public async Task AddGenre(ModelClasses.Genre genre)
    {
        await _genreNetworking.AddGenre(genre);
    }

    public async Task<List<ModelClasses.Genre>> GetAllGenre()
    {
       return await _genreNetworking.getAllGenre();
    }
}