namespace BusinessLogicServer.Networking.Orders;

public interface IOrderNetworking
{
    // commented, as there is no longer use of Order.cs object within the project. Instead of it, there is OrdersDTO.cs,
    // which has been implemented in another Interface.
    // public Task<List<Order>> GetAllOrdersAsync();
    public Task CreateOrderAsync(Order order);
}