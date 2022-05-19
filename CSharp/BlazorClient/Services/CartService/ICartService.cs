using ModelClasses;

namespace BlazorClient.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(OrderLineDTO item);
    Task<ServiceResponse<long>> CreateOrder(OrderDTO order);
    Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long orderId);
    Task<ServiceResponse<List<ShoppingCartItem>>> GetShoppingCart(long serialOrder);
    Task<ServiceResponse<long>> GetSerialOrder(UsernameDateStatus usernameDateStatus);
    Task<ServiceResponse<long>> CheckOut(long serialOrder);

    Task RemoveProductFromCart(OrderLineDTO item); 
    Task<ServiceResponse<List<OrderDTO>>> GetAllOrdersByUsernameAsync(string username);
}