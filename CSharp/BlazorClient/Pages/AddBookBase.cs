using System.Reflection;
using BlazorClient.Services.ImageService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorClient.Pages;

public class AddBookBase : ComponentBase
{
    [Inject]
    public IBookService BookService { get; set; }
    [Inject]
    private IImageService ImageService { set; get; }
    public Book BookToAdd = new Book();
    public List<Genre> genres = new()
    {
        new Genre
        {
            Name = "Drama",
            Url = "something"
        },
        new Genre
        {
            Name = "Scientific",
            Url = "something else"
        },
        new Genre
        {
            Name = "Crime",
            Url = "no url"
        }
        
    };
    public async Task TryAddBookAsync()
    {
        await BookService.AddBookAsync(BookToAdd);
    }

    public void SelectedGenreChanged(ChangeEventArgs obj)
    {
        List<Genre> genres = this.genres.FindAll(genre => ((string[]) obj.Value).All(g => g.Equals(genre.Name)));
        BookToAdd.Genres =  genres;
    }

    public async Task SaveImageAsync(InputFileChangeEventArgs arg)
    {
        var uploadImageAsync = await ImageService.UploadImageAsync(arg.File);
        BookToAdd.ImageUrl = uploadImageAsync;
    }
}