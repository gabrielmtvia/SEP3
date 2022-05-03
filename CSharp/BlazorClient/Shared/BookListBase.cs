using BlazorClient.Services.BookService;
using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Shared;

public class BookListBase : ComponentBase
{
    [Inject]
    public IBookService BookService { get; set; }
    public List<Book> Books { get; set; }

    public BookListBase()
    {
        Books = new List<Book>();
    }

    protected override async Task OnInitializedAsync()
    {
        Books = await BookService.GetBooks();
    }
}