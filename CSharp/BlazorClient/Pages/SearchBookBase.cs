using BlazorClient.Services.BookService;
using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Pages;

public class SearchBookBase : ComponentBase
{
    [Inject] 
    public IBookService BookService { get; set; }
    public IEnumerable<Book> books { get; set; }
}