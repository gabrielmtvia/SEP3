using ModelClasses;

namespace BusinessLogicServer.Models.Genre;




public interface IGenreModel
{
    public Task AddGenre(ModelClasses.Genre genre);
    public Task<List<ModelClasses.Genre>> GetAllGenre();
}