using System.Collections;

public class Genre
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

    public Genre()
    {
    }

    // create Genre object from message
    public Genre(GenreMessage genre)
    {
        Name = genre.Name;
        Url = genre.Url;
    }

    public GenreMessage BuildGenreMessage()
    {
        return new GenreMessage
        {
            Name = this.Name,
            Url = this.Url
        };
    }
    
    public static ListGenreMessage BuildListGenreMessage(List<Genre> genres)
    {
        List<GenreMessage> messages = new List<GenreMessage>();
        foreach (var genre in genres)
        {
            messages.Add(genre.BuildGenreMessage());
        }

        return new ListGenreMessage
        {
            Genres =
            {
                messages
            }
        };
    }
    
    public static List<Genre> FromListMessageToGenreList(ListGenreMessage genres)
    {
        List<Genre> genrs = new List<Genre>();
    
        foreach (var g in genres.Genres)
        {
            genrs.Add(new Genre(g));
        }
    
        return genrs;
    }
    
 
}