using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public interface IOrderModel
{
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    public Task<UserDTO> GetCustomer(string orderUsername);
    public Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId);
    public Task UpdateOrderStatusAsync(long orderId, string orderStatus);
    public Task<OrdersDTO> GetOrderById(long orderId);
}