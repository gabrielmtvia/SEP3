namespace BusinessLogicServer.Service.CartService;

public interface ICartService
{
    List<OrderLineDTO> ShoppingCart { get; set; }
    public List<OrderDTO> OrderList { get; set; }
    Task AddToCart(OrderLineDTO item);
    Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long serialOrder);

    Task<long> CreateOrder(OrderDTO orderDto);
}