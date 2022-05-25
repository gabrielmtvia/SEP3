using BusinessLogicServer.Networking.Order;
using ModelClasses;

namespace BusinessLogicServer.Models.Order;

public class OrderModel:IOrderModel
{
    private IOrderNetworking _orderNetworking;

    public OrderModel(IOrderNetworking orderNetworking)
    {
        _orderNetworking = orderNetworking;
    }


    public  async Task<List<OrdersDTO>> GetAllOrdersAsync()
    {
        var orders = await _orderNetworking.GetAllOrdersAsync();
        orders = (from order in orders orderby order.id select order).ToList();
        return orders;
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await _orderNetworking.GetCustomer(orderUsername);
    }

    public async Task<List<OrdersDTO>> GetAllOrdersByStatusAsync(string status)
    {
        var orders = await _orderNetworking.GetAllOrdersByStatusAsync(status);
        orders = (from order in orders orderby order.id select order).ToList();
        return orders;
    }

    public  async Task<List<OrderLineDTO>> GetOrderLines(long id)
    {
        return await _orderNetworking.GetOrderLines(id);
    }

    public async Task UpdateOrderStatus(long id, string status)
    {
        await _orderNetworking.UpdateOrderStatus(id, status);
    }
}