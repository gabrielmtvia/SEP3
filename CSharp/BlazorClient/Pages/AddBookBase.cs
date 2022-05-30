using System.Reflection;
using BlazorClient.Services.BookService;
using BlazorClient.Services.GenreService;
using BlazorClient.Services.ImageService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using ModelClasses;
using SixLabors.ImageSharp.Processing.Processors.Filters;

namespace BlazorClient.Pages;

public class AddBookBase : ComponentBase
{
    [Inject] private IBookService BookService { get; set; }
    [Inject] private IImageService ImageService { set; get; }
    [Inject] private IGenreService GenreService { set; get; }
    [Inject] private NavigationManager NavigationManager { set; get; }
    
    [Parameter] public String Isbn { set; get; }
    public bool isDisabled = false;
    public String buttonName = "ADD BOOK";
    
    public Book BookToAdd = new Book();
    public List<Genre> genres = new();
    public string[] selectedGenre { get; set; } = new string[]{};

    protected override async Task OnInitializedAsync()
    {
        genres = await GenreService.GetAllGenresAsync();

        if (Isbn != null)
        {
            BookToAdd = await BookService.GetBookByIsbnAsync(Isbn);
            isDisabled = true;
            buttonName = "EDIT BOOK";
            //selectedGenre = BookToAdd.Genres.Select(g => g.Name).ToArray();
        }
    }

    public async Task TryAddBookAsync()
    {
        BookToAdd.Genres = new List<Genre>();
        if (selectedGenre.Length!=0)
        {
            foreach (string s in selectedGenre)
            {
                Console.WriteLine(s);

                Genre genre = new Genre()
                {
                    Name = s
                };
                BookToAdd.Genres.Add(genre);
            }

            
        }
        else
        {
            Genre genre = new Genre()
            {
                Name = "NoGenre"
            };
            BookToAdd.Genres.Add(genre);
            
        }
        
      
        await BookService.AddBookAsync(BookToAdd);
        NavigationManager.NavigateTo("/AllBooks");
    }
    
    public void SelectedGenreChanged(ChangeEventArgs e)
    {
        selectedGenre = (String[]) e.Value;
    }

    public async Task SaveImageAsync(InputFileChangeEventArgs arg)
    {
        var uploadImageAsync = await ImageService.UploadImageAsync(arg.File);
        BookToAdd.ImageUrl = uploadImageAsync;
    }

   
} 

