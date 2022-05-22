using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;

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
        username = authenticationStateTask.Result.User.Identity.Name;
        await LoadCart();
    }
    
    public async Task LoadCart()
    {
        var response = await _cartService.GetAllOrdersByUsernameAsync(username);
        
        if (response.Success && response.Data !=null)
        {
            var currentOrder = response.Data.Find(o => o.Status == OrderStatus.NotConfirmed);

            if (currentOrder != null)
            {
                serialOrder = currentOrder.SerialOrder;
                ShoppingCartItems = _cartService.GetShoppingCart(serialOrder).Result.Data;
                if (ShoppingCartItems.Count == 0)
                {
                    message = "Your cart is empty";
                }

                else
                {
                    message = "";
                }
            }
            else
            {
                //message = "You haven't added any product yet. Please review our catalog and add some items to the cart";
            }
            
        }

        
        else
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
            message = "You haven't added any product yet. Please review our catalog and add some items to the cart";
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

    public async Task RemoveProductFromCart(string isbn, int quantity)
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

    public async Task UpdateQuantity(ChangeEventArgs e, ShoppingCartItem item)
    {
        int quantity = 0;
        
        if (!e.Equals(null) && !e.Value.Equals(null))
        {
            quantity = Int32.Parse(e.Value.ToString());
        }

        
        if (quantity == 0)
        {
            await RemoveProductFromCart(item.Isbn, item.Quantity);
        }

        else
        {
            if (quantity < 0) quantity = 1;

            OrderLineDTO updateQuantity = new OrderLineDTO()
            {
                Quantity = quantity,
                SerialOrder = serialOrder,
                Isbn = item.Isbn
            };

            await _cartService.AddToCart(updateQuantity);

        }

        Console.WriteLine("Update method");
        await LoadCart();

    }
}
