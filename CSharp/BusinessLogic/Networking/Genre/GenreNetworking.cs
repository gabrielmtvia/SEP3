namespace BusinessLogicServer.Networking.Genre;

public class GenreNetworking:IgenreNetworking
{
    private GenreService.GenreServiceClient GenreServiceClient;

    public GenreNetworking(GenreService.GenreServiceClient genreServiceClient)
    {
        GenreServiceClient = genreServiceClient;
    }


    public async Task AddGenre(ModelClasses.Genre genre)
    {
      await  GenreServiceClient.createGenreAsync(new GenreMessage
        {
         Type = genre.Name
        });
       
    }

    public async Task<List<ModelClasses.Genre>> getAllGenre()
    {
        var  genres = new List<ModelClasses.Genre>();
        var allGenresAsync = await GenreServiceClient.getAllGenresAsync(new EmptyGenreMessage());
        var genreMessage = allGenresAsync.GenreMessage;
        foreach (var genreProto in genreMessage)
        {
            var genre = new ModelClasses.Genre
            {
                Name = genreProto.Type

            };
            genres.Add(genre);

        }

        
        
        return genres;
    }
}