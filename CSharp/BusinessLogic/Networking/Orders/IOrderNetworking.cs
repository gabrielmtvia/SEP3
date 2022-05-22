using ModelClasses;

namespace BusinessLogicServer.Networking.Orders;

public interface IOrderNetworking
{
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    public Task<UserDTO> GetCustomer(string orderUsername);
    public Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId);
    public Task UpdateOrderStatusAsync(long orderId, string orderStatus);
}