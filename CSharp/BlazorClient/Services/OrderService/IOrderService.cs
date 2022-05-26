using ModelClasses;

namespace BlazorClient.Services.OrderService;

public interface IOrderService
{
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    public Task<ICollection<OrdersDTO>> GetAllOrdersByUsernameAsync(string username); 
    public Task<UserDTO> GetCustomer(string orderUsername);
    public Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId);
    public Task UpdateOrderStatusAsync(OrdersDTO order);
    public Task<OrdersDTO> GetOrderById(long orderId);
}