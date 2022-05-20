using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ModelClasses;

namespace BlazorClient.Pages;

public class AddBookBase : ComponentBase
{
    [Inject] public IAuthService Authentication { get; set; }
    [Inject]
    public IBookService BookService { get; set; }
    public Book BookToAdd = new Book();
    public List<string> genres = new() {"Action", "Fantasy", "Drama", "Horror", "Classics", "History", "Crime", "Mystery" };
    public ImageFile imageFile;
    
    
    private User _user;
    
    protected override async Task OnInitializedAsync()
    {   
        _user = await Authentication.GetUserFromCacheAsync();
        Console.WriteLine(_user.userName+_user.password+_user.role+" YYYYYYYYYY");
        
    }
    public async Task TryAddBookAsync()
    {
        await BookService.AddBookAsync(BookToAdd);
    }

    public void SelectedGenreChanged(ChangeEventArgs obj)
    {
        foreach (var str in (string[]) obj.Value!)
        {
            Console.WriteLine(str);
        }
    }

    public async Task SaveImageAsync(InputFileChangeEventArgs arg)
    {
        
        var browserFile = arg.File;
        var requestImageFileAsync = await browserFile.RequestImageFileAsync(browserFile.ContentType, 1000, 800);
        var buffer = new byte[requestImageFileAsync.Size];
        using (var stream = requestImageFileAsync.OpenReadStream())
        {
            await stream.ReadAsync(buffer);
        }

      /*  imageFile = new ImageFile()
        {
            Base64Data = Convert.ToBase64String(buffer),
            ContentType = requestImageFileAsync.ContentType,
            FileName = requestImageFileAsync.Name
        }; */
        
        

    }
}

public class ImageFile
{
    // we do not upload images we upload urls for an image
    
}