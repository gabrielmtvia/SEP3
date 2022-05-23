using ModelClasses;

namespace BusinessLogicServer.Networking.Orders;

public interface IOrderNetworking
{
    Task<List<OrdersDTO>> GetAllOrdersAsync();
    Task<UserDTO> GetCustomer(string orderUsername);
    Task<List<OrdersDTO>> GetAllOrdersByStatusAsync(string status);
    Task<List<JoinDTO>> GetOrderLines(long id);
    Task UpdateOrderStatus(long id, string status);
}