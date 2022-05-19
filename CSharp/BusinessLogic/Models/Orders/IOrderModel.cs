using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public interface IOrderModel
{
    public Task<List<Order>> GetAllOrdersAsync();
    public Task CreateOrderAsync(Order order);
}