using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public interface IOrderModel
{
    public Task<List<OrdersDTO>> GetAllOrdersAsync();
    public Task<UserDTO> GetCustomer(string orderUsername);
    
    public Task<List<OrdersDTO>> GetAllOrdersByStatusAsync(string status);
    
    public Task<List<JoinDTO>> GetOrderLines(long id);
    
    public Task UpdateOrderStatus(long id, string status);
}