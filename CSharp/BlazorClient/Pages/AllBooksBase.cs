using BlazorClient.Services.BookService;
using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Pages;

public class AllBooksBase : ComponentBase
{
    [Inject] public IBookService BookService { get; set; }
    public List<Book> AllBooks { get; set; } = new();
    public string SearchName = "";
    [Inject] 
    private NavigationManager navManager { get; set; }
    public List<Book> DisplayBooks { get; set; } = new();



    protected override async Task OnInitializedAsync()
    {
        AllBooks = await BookService.GetAllBooksAsync();
        DisplayBooks = AllBooks;
    }

    public async Task FilterBooksAsync()
    {
        DisplayBooks = AllBooks.Where(b => b.Title.ToLower().Contains(SearchName.ToLower())).ToList();
    }

    public async Task DeleteBookAsync(string isbn)
    {
        await BookService.DeleteBookAsync(isbn);
        DisplayBooks = await BookService.GetAllBooksAsync();
    }

    public async Task EditBookAsync(string isbn)
    {
       navManager.NavigateTo($"/EditBook/{isbn}");
    }


      
    
   
}
     
    
