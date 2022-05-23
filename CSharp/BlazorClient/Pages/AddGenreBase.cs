using System.Runtime.InteropServices;
using BlazorClient.Services.GenreService;
using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorClient.Pages;

public class AddGenreBase : ComponentBase
{
    [Inject]
    public IGenreService GenreService { get; set; }

    [Inject] private NavigationManager NavigationManager { set; get; }

    public Genre GenreToAdd = new Genre();
    

    public List<Genre> genres = new();

    public async Task TryAddGenreAsync()
    {
       await GenreService.AddGenreAsync(GenreToAdd);
       await OnInitializedAsync();

    }

    public async Task DeleteGenreAsync(string type)
    {
        await GenreService.DeleteGenreAsync(type);
    }  

    protected override async Task OnInitializedAsync()
    {
        genres = await GenreService.GetAllGenresAsync();
    }
    
    public void OnChange(object args)
    {
        GenreToAdd.Type = args.ToString();
    }
    
    public void RemoveGenre(Genre value)
    {
        throw new NotImplementedException();
    }
}