using ModelClasses;

namespace BusinessLogicServer.Networking.Orders;

public interface IOrderNetworking
{
    public Task<List<Order>> GetAllOrdersAsync();
    public Task CreateOrderAsync(Order order);
}