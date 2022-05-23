namespace ModelClasses;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }  // = string.Empty;
    public string Url { get; set; } // = string.Empty;

    public Genre()
    {
    }

    public Genre(string name)
    {
        Name = name;
    }
}