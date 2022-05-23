using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public interface IOrderModel
{
    Task<IList<OrdersDTO>> GetOrdersByStatusAsync(string status);
    Task<IList<OrdersDTO>> GetAllOrdersAsync();
    Task<UserDTO> GetCustomer(string orderUsername);
    Task<IList<JoinDTO>> GetOrderLines(long orderId);
    Task UpdateOrderStatusAsync(long orderId, string orderStatus);
}