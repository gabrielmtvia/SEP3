using BlazorClient.Services.BookService;
using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;

namespace BlazorClient.Pages;

public class CartBase : ComponentBase
{
    public List<ShoppingCartItem> ShoppingCartItems = new List<ShoppingCartItem>();
    public string message = "Loading cart...";
    public string username = string.Empty;
    
    [Inject] public ICartService _cartService { get; set; }
    [Inject] public IBookService _bookService { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    protected override async Task OnInitializedAsync()
    {
        username = authenticationStateTask.Result.User.Identity.Name;
        await LoadCart();
        message = "";
    }
    
    public async Task LoadCart()
    {
        ShoppingCartItems = new List<ShoppingCartItem>();
        
        var orderList = await _cartService.GetCartItems(username);

        foreach (var lineDto in orderList)
        {
            var book = await _bookService.GetBookByIsbnAsync(lineDto.Isbn);
            
                ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    Author = book.Author, 
                    ImageUrl = book.ImageUrl, 
                    Isbn = book.Isbn, 
                    Price = book.Price, 
                    Quantity = lineDto.Quantity, 
                    Title = book.Title, 
                    Edition = book.Edition
                });
            
        }
        

    }
    
    public async Task CheckOut()
    {
        await _cartService.CheckOutCart(username);
        message = "Your order has been confirmed";
        await LoadCart();
    }

    public async Task RemoveProductFromCart(string isbn)
    {
        OrderLineDTO item = new OrderLineDTO()
        {
            Isbn = isbn
        };
        await _cartService.RemoveBookFromCart(item, username);
        await LoadCart();
    }

    public async Task UpdateQuantity(ChangeEventArgs e, ShoppingCartItem item)
    {
        int quantity = 0;
        
        if (!e.Equals(null) && !e.Value.Equals(null))
        {
            quantity = Int32.Parse(e.Value.ToString());
        }

        
        if (quantity == 0)
        {
            await RemoveProductFromCart(item.Isbn);
        }

        else
        {
            if (quantity < 0) quantity = 1;

            OrderLineDTO updateQuantity = new OrderLineDTO()
            {
                Quantity = quantity,
                Isbn = item.Isbn
              
            };

            await _cartService.UpdateCart(updateQuantity, username);

        }
        
        await LoadCart();

    }
}
