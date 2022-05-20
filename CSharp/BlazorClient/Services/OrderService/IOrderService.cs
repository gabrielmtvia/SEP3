using ModelClasses;

namespace BlazorClient.Services.OrderService;

public interface IOrderService
{
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrders();
    void CreateOrder(Order o);
    void DeleteOrder(long orderId);
}