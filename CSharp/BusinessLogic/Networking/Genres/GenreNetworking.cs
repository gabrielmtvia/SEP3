namespace BusinessLogicServer.Networking.Genres;

public class GenreNetworking : IGenreNetworking
{

    private GenreGrpcService.GenreGrpcServiceClient client;

    public GenreNetworking(GenreGrpcService.GenreGrpcServiceClient client)
    {
        this.client = client;
    }
   
    public async Task AddGenreAsync(Genre genre)
    {
        var buildGenreMessage = genre.BuildGenreMessage();
        var addGenre = await client.addGenreAsync(buildGenreMessage);
    }
    
  
    public async Task<List<Genre>> GetAllGenreAsync()
    {
        var requestVoidMessage = new VoidMessage();
        var responseAllGenreAsync = await client.getAllGenreAsync(requestVoidMessage);
        var genres = new List<Genre>();

        foreach (var genreMessage in responseAllGenreAsync.Genres)
        {
            var toAdd = new Genre
            {
                Type = genreMessage.Name
            };
          genres.Add(toAdd);
        }

        return genres;
    }

    public async Task DeleteGenreAsync(string type)
    {
        throw new NotImplementedException();
    }
    

}