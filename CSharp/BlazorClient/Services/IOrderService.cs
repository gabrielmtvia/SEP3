using BlazorClient.Model;

namespace BlazorClient.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrders();
    void CreateOrder(Order o);
    void DeleteOrder(long orderId);
}