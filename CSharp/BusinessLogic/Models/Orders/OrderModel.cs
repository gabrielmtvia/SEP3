using BusinessLogicServer.Networking.Orders;
using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public class OrderModel : IOrderModel
{
    private IOrderNetworking networking;

    public OrderModel(IOrderNetworking networking)
    {
        this.networking = networking;
    }

    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        return await networking.GetOrdersByStatusAsync(status);
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        return await networking.GetAllOrdersAsync();
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await networking.GetCustomer(orderUsername);
    }

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return await networking.GetOrderLines(orderId);
    }

    public async Task UpdateOrderStatusAsync(long orderId, string orderStatus)
    {
        await networking.UpdateOrderStatusAsync(orderId, orderStatus);
    }
}