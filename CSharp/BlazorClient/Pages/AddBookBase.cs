using System.Reflection;
using BlazorClient.Services.BookService;
using BlazorClient.Services.GenreService;
using BlazorClient.Services.ImageService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ModelClasses;

namespace BlazorClient.Pages;

public class AddBookBase : ComponentBase
{
    [Inject]
    private IBookService BookService { get; set; }
    [Inject]
    private IImageService ImageService { set; get; }
    [Inject]
    private IGenreService GenreService { set; get; }
    
    public Book BookToAdd = new Book();
    public List<Genre> genres = new();

    protected override async Task OnInitializedAsync()
    {
      genres= await GenreService.GetAllGenresAsync();
    }

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