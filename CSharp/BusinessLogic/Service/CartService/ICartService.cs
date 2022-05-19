using ModelClasses;

namespace BusinessLogicServer.Service.CartService;

public interface ICartService
{
    List<OrderLineDTO> ShoppingCart { get; set; }
    Task AddToCart(OrderLineDTO item);
    Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long serialOrder);
    Task<ServiceResponse<long>> CreateOrder(OrderDTO orderDto);
    Task<ServiceResponse<List<ShoppingCartItem>>> GetShoppingCart(long serialOrder);
    Task<ServiceResponse<long>> GetSerialOrder(string username, string date, OrderStatus status);
    Task<ServiceResponse<long>> CheckOut(long serialOrder);
    Task RemoveProductFromCartAsync(OrderLineDTO item);
    Task<ServiceResponse<List<OrderDTO>>> GetAllOrdersByUsernameAsync(string username);
}