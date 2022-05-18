using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorClient.Pages;

public class CustomerOrderHistoryBase : ComponentBase
{
    public string Message = string.Empty;
    public string Username = string.Empty;
    public List<ShoppingCartItem> CurrentOrder = new List<ShoppingCartItem>();
    public List<OrderDTO> OrderList = new List<OrderDTO>();
    public long CurrentSerialOrder;
    public OrderStatus CurrentOrderStatus;

    [Inject] private ICartService _cartService { get; set; }
    [Inject] private IBookService _bookService { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        await Load();
    }
    
    public async Task Load()
    {
        Username = authenticationStateTask.Result.User.Identity.Name;

        var response = await _cartService.GetAllOrdersByUsernameAsync(Username);

        if(response.Success && response.Data != null)
            OrderList = response.Data;
        else
        {
            Message = response.Message;
        }
    }

    public async Task LoadOrder(long serialOrder)
    {
        CurrentSerialOrder = serialOrder;
        var order = OrderList.Find(o => o.SerialOrder == serialOrder);
        
        if (order != null)
        {
            CurrentOrderStatus = order.Status;
        }

        var result = await _cartService.GetShoppingCart(serialOrder);
        
        if (result.Success && result.Data != null)
            CurrentOrder = result.Data;
        else Message = result.Message;
    }
}