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
       return  await _orderNetworking.GetAllOrdersAsync();
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await _orderNetworking.GetCustomer(orderUsername);
    }

    public async Task<List<OrdersDTO>> GetAllOrdersByStatusAsync(string status)
    {
        return await _orderNetworking.GetAllOrdersByStatusAsync(status);
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