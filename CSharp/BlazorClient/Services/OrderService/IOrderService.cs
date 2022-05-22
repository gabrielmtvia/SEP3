using ModelClasses;

namespace BlazorClient.Services.OrderService;

public interface IOrderService
{
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    public Task<UserDTO> GetCustomer(string orderUsername);
    public Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId);
    public Task<IEnumerable<Order>> GetOrders();
    void CreateOrder(Order o);
    void DeleteOrder(long orderId);
    public Task UpdateOrderStatusAsync(OrdersDTO order);
}