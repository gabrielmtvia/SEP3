using System.Reflection;
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
    [Inject]
    private NavigationManager navigationManager { set; get; }

    public bool isDisabled = false;
    
    [Parameter]
    public String Isbn { set; get; }
    
    public Book BookToAdd = new Book();
    public List<Genre> genres = new();

    protected override async Task OnInitializedAsync()
    {
      genres= await GenreService.GetAllGenresAsync();
      if (Isbn != null)
      {
          BookToAdd = await BookService.GetBookByIsbnAsync(Isbn);
          isDisabled = true;
      }
    }

    public async Task TryAddBookAsync()
    {
        if (Isbn == null)
        {
            await BookService.AddBookAsync(BookToAdd);
        }
        else
        {
            await BookService.EditBook(BookToAdd);
        }
        
        navigationManager.NavigateTo("/AllBooks");
    }

    public void SelectedGenreChanged(ChangeEventArgs obj)
    {
        List<Genre> genres = this.genres.FindAll(genre => ((string[]) obj.Value).All(g => g.Equals(genre.Type)));
        BookToAdd.Genres =  genres;
    }

    public async Task SaveImageAsync(InputFileChangeEventArgs arg)
    {
        var uploadImageAsync = await ImageService.UploadImageAsync(arg.File);
        BookToAdd.ImageUrl = uploadImageAsync;
    }
}