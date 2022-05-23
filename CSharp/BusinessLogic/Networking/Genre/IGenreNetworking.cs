namespace BusinessLogicServer.Networking.Genre;



public interface IgenreNetworking
{
    Task AddGenre(ModelClasses.Genre genre);
    Task<List<ModelClasses.Genre>> getAllGenre();
}