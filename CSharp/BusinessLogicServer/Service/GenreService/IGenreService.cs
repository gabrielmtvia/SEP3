namespace BusinessLogicServer.Service.GenreService;

public interface IGenreService
{
    Task<ServiceResponse<List<Genre>>> GetGenresAsync();
}