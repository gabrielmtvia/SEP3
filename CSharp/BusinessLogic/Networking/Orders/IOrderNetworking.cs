using ModelClasses;

namespace BusinessLogicServer.Networking.Orders;

public interface IOrderNetworking
{
    // commented, as there is no longer use of Order.cs object within the project. Instead of it, there is OrdersDTO.cs,
    // has been implemented in another method. If any problems, please contact @Tomasz G.
    // public Task<List<Order>> GetAllOrdersAsync();
    public Task CreateOrderAsync(Order order);
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    public Task<UserDTO> GetCustomer(string orderUsername);
    public Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId);
}