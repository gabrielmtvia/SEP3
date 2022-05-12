namespace BlazorClient.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(OrderLineDTO item);
    Task<long> CreateOrder(OrderDTO order);
    Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long orderId);
}