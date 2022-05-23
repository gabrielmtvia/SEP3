using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Pages;

public class AllBooksBase : ComponentBase
{
    [Inject] public IBookService BookService { get; set; }
    public List<Book> AllBooks { get; set; }


    protected override async Task OnInitializedAsync()
    {
        AllBooks = await BookService.GetAllBooksAsync();
    }
    
    /*
   private void OpenBook(Book obj)
    {
        NavigationManager.NavigateTo($"/viewbook/{obj.Id}");   OR Isbn
    }

}
     */
    
}