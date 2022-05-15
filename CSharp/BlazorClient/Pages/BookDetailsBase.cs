using System.Reflection.Metadata;
using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorClient.Pages;

public class BookDetailsBase : ComponentBase {
    public Book? Book;
    public string Message = string.Empty;
    public long OrderId { get; set; }
    public string Username = string.Empty;
    [Inject] private ICartService _cartService { get; set; }
    [Inject] private IBookService _bookService { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    [Parameter]
    public long Isbn { get; set; }

    public async Task CreateShoppingCart()
    {
        var result = authenticationStateTask.Result.User.Identity.Name;
        Console.WriteLine(result);
        if (result != null)
        {
            OrderDTO newOrder = new OrderDTO()
            {
                Date = DateTime.Today.ToString("dd-MM-yyyy"),
                Username = result,
                Status = OrderStatus.NotConfirmed
            };
            var response = await _cartService.CreateOrder(newOrder);
            OrderId = response.Data;
            Console.WriteLine(DateTime.Today.ToString("dd-MM-yyyy") + "order id" + OrderId + result + response.Message);
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        Message = "Loading products";
        var result = await _bookService.GetBookAsync(Isbn);
        if (!result.Success)
        {
            Message = result.Message;
        }
        else
        {
            Book = result.Data;
        }
    }

    public async Task AddToCart()
    {
        var response = await _cartService.GetSerialOrder(new UsernameDateStatus() {Date = DateTime.Today.ToString("dd-MM-yyyy"), Username = Username, Status = OrderStatus.NotConfirmed});
        if (response.Success)
        {
            OrderId = response.Data;
            Console.WriteLine("Current order " + response.Data);
        }
        else
        {
            Console.WriteLine(response.Message + "Add to cart method");
            await CreateShoppingCart();
        }
        
        var orderLine = new OrderLineDTO
        {
            SerialOrder = OrderId,
            Isbn = Book.Isbn,
            Quantity = 1
        };

        await _cartService.AddToCart(orderLine);
        Console.WriteLine("Order ID is " + OrderId);
    }

    public async Task PrintOutShoppingCart()
    {
        var result = _cartService.GetCartItems(OrderId).Result;
        Console.WriteLine("OrderID is " + OrderId);

        List<OrderLineDTO> data = new List<OrderLineDTO>();

        if (result.Data != null)
            data = result.Data;
        
        Console.WriteLine(result.Message);

        foreach (var order in data)
        {
            Console.WriteLine(order.Isbn);
            Console.WriteLine(order.Quantity);
            Console.WriteLine(order.SerialOrder);
        }
    }

}