namespace BusinessLogicServer.Service.CartService;

public interface ICartService
{
    List<OrderLineDTO> ShoppingCart { get; set; }
    Task AddToCart(OrderLineDTO item);
    Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long serialOrder);
    Task<long> CreateOrder(OrderDTO orderDto);
    Task<ServiceResponse<List<ShoppingCartItem>>> GetShoppingCart(long serialOrder);
    Task<ServiceResponse<long>> GetSerialOrder(string username, string date);
}