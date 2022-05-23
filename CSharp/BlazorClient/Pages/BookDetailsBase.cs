using System.Reflection.Metadata;
using BlazorClient.Services.CartService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;

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
    public string Isbn { get; set; } = String.Empty;

    public async Task CreateShoppingCart()
    {
        var result = authenticationStateTask.Result.User.Identity.Name;
        
        if (result != null)
        {
            Username = result;
            var response = await _cartService.GetAllOrdersByUsernameAsync(Username);
            if (response.Success && response.Data !=null)
            {
                var currentOrder = response.Data.Find(o => o.Status == OrderStatus.NotConfirmed);

                if (currentOrder != null)
                {
                    OrderId = currentOrder.SerialOrder;
                }
                else
                {
                    OrderDTO newOrder = new OrderDTO()
                    {
                        Date = DateTime.Today.ToString("dd-MM-yyyy"),
                        Username = result,
                        Status = OrderStatus.NotConfirmed
                    };
                    var response2 = await _cartService.CreateOrder(newOrder);
                    OrderId = response2.Data;
                }
                
            }
            
            else
            {
                OrderDTO newOrder = new OrderDTO()
                {
                    Date = DateTime.Today.ToString("dd-MM-yyyy"),
                    Username = result,
                    Status = OrderStatus.NotConfirmed
                };
                var response2 = await _cartService.CreateOrder(newOrder);
                OrderId = response2.Data;
            }
        }
    }
/*
    protected override async Task OnParametersSetAsync()
    {
        Message = "Loading products";
        var result = await _bookService.GetBookByIsbnAsync(Isbn);
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
        await CreateShoppingCart();
        
        var orderLine = new OrderLineDTO
        {
            SerialOrder = OrderId,
            Isbn = Book.Isbn,
            Quantity = 1
        };

        await _cartService.AddToCart(orderLine);
        Console.WriteLine("Order ID is " + OrderId);
    }  */

   
}