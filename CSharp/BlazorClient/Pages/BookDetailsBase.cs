using System.Reflection.Metadata;
using BlazorClient.Services.BookService;
using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;

namespace BlazorClient.Pages;

public class BookDetailsBase : ComponentBase {
    public Book? Book;
    public string Message = string.Empty;
    public string Username = string.Empty;
    [Inject] private ICartService _cartService { get; set; }
    [Inject] private IBookService _bookService { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    [Parameter]
    public string Isbn { get; set; } = String.Empty;

    
    protected override async Task OnParametersSetAsync()
    {
        Message = "Loading products";
        Book = await _bookService.GetBookByIsbnAsync(Isbn);
        
        var user = await authenticationStateTask;
        if (user.User.Identity != null && !user.Equals(null) && !user.User.Identity.Equals(null))
            if (user.User.Identity.Name != null)
                Username = user.User.Identity.Name;
    }

    public async Task AddToCart()
    {
        var orderLine = new OrderLineDTO
        {
            Isbn = Book.Isbn,
            Quantity = 1
        };

        await _cartService.AddToCart(orderLine, Username);
        
    }

   
}