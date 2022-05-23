using ModelClasses;

namespace BlazorClient.Services.CartService;

public interface ICartService2
{
    Task AddToCart(OrderLineDTO orderLineDto, string username);
    Task<List<OrderLineDTO>> GetCartItems(string username);

    Task RemoveBookFromCart(OrderLineDTO orderLineDto, string username);
    Task UpdateCart(OrderLineDTO orderLineDto, string username);

    Task CheckOutCart(string username);
}