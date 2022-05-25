using BlazorClient.Services.BookService;
using BlazorClient.Services.CartService;
using BlazorClient.Services.OrderService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;
using SixLabors.ImageSharp.Processing;

namespace BlazorClient.Pages;

public class CustomerOrderHistoryBase : ComponentBase
{
    public string Message = string.Empty;
    public string Username = string.Empty;
    public List<ShoppingCartItem> CurrentOrder = new List<ShoppingCartItem>();
    public List<OrdersDTO> OrderList = new List<OrdersDTO>();
    public long CurrentSerialOrder;
    public string CurrentOrderStatus;

    [Inject] private ICartService _cartService { get; set; }
    [Inject] private IBookService _bookService { get; set; }
    [Inject] private IOrderService _orderService { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        await Load();
    }
    
    public async Task Load()
    {
        Username = authenticationStateTask.Result.User.Identity.Name;

        var response = await _orderService.GetAllOrdersAsync();

        foreach (var order in response)
        {
            if (order.username.Equals(Username))
            {
                OrderList.Add(order);
            }
        }
    }

    public async Task LoadOrder(long id)
    {
        CurrentSerialOrder = id;
        var order = OrderList.Find(o => o.id == CurrentSerialOrder);
        
        if (order != null)
        {
            CurrentOrderStatus = order.status;
        }

        var response = await _orderService.GetOrderLines(id);

        CurrentOrder = new List<ShoppingCartItem>();
        
        foreach (var orderLine in response)
        {
            var book = await _bookService.GetBookByIsbnAsync(orderLine.Isbn);
            CurrentOrder.Add(new ShoppingCartItem()
            {
                Title = book.Title,
                Author = book.Author,
                Edition = book.Edition,
                ImageUrl = book.ImageUrl,
                Isbn = book.Isbn,
                Price = book.Price,
                Quantity = orderLine.Quantity
            });
        }
        
    }
}