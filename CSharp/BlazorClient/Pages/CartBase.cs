using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorClient.Pages;

public class CartBase : ComponentBase
{
    public List<ShoppingCartItem> ShoppingCartItems = new List<ShoppingCartItem>();
    public string message = "Loading cart...";
    public long serialOrder;
    public string username = string.Empty;
    
    [Inject] public ICartService _cartService { get; set; }
    [Inject] public IBookService _bookService { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadCart();
    }
    
    public async Task LoadCart()
    {
        UsernameDateStatus usernameDateStatus = new UsernameDateStatus
        {
            Username = authenticationStateTask.Result.User.Identity.Name,
            Date = DateTime.Today.ToString("dd-MM-yyyy"),
            Status = OrderStatus.NotConfirmed
        };

        var result = await _cartService.GetSerialOrder(usernameDateStatus);
       
        if (result.Success)
        {
            serialOrder = result.Data;
            ShoppingCartItems = _cartService.GetShoppingCart(serialOrder).Result.Data;
            if (ShoppingCartItems.Count == 0)
                message = "Your cart is empty";
            else
            {
                message = "";
            }
        }
        else
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            message = "New shopping cart created";
        }
        
    }

    public async Task CheckOut()
    {
        var response = await _cartService.CheckOut(serialOrder);
        
        if (response.Success)
        {
            message = response.Message;
        }
        else
        {
            message = response.Message;
           
        }

        await LoadCart();
    }

    public async Task RemoveProductFromCart(long isbn, int quantity)
    {
        OrderLineDTO item = new OrderLineDTO()
        {
            Isbn = isbn,
            SerialOrder = serialOrder,
            Quantity = quantity
        };
        await _cartService.RemoveProductFromCart(item);
        await LoadCart();
    }
}
