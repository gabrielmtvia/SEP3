namespace BlazorClient.Services.OrderService;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrders();
    void CreateOrder(Order o);
    void DeleteOrder(long orderId);
}