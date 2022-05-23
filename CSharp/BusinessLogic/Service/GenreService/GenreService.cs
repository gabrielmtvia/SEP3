using ModelClasses;

namespace BusinessLogicServer.Service.GenreService;

public class GenreService : IGenreService
{
    public List<Genre> Categories = new()
    {
        new()
        {
          //  Id = 1,
            Name = "Science Fiction",
           // Url = "Science-Fiction"
        },
        new()
        {
           // Id = 2,
            Name = "Historical Novels",
         //   Url = "Historical-Novels"
        },
        new()
        {
           // Id = 3,
            Name = "English Literature",
           // Url = "English-Literature"
        },
        new()
        {
           // Id = 4,
            Name = "Hollywood Novels",
           // Url = "Hollywood-Novels"
        },
        new()
        {
          //  Id = 5,
            Name = "Poetry Collections",
           // Url = "Poetry"
        },
        new()
        {
           // Id = 6,
            Name = "Novels based on comics",
           // Url = "Novels-based-on-comics"
        }
    };

    public async Task<ServiceResponse<List<Genre>>> GetGenresAsync()
    {
        return new ServiceResponse<List<Genre>>
        {
            Data = Categories
        };
    }
}