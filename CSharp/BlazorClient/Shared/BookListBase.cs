using BlazorClient.Services.BookService;
using Microsoft.AspNetCore.Components;


namespace BlazorClient.Shared;

public class BookListBase : ComponentBase, IDisposable
{
    [Inject] public IBookService BookService { get; set; }

    protected override void OnInitialized()
    {
        BookService.BooksChanged += StateHasChanged;
    }

    public void Dispose()
    {
        BookService.BooksChanged -= StateHasChanged;
    }
    
}