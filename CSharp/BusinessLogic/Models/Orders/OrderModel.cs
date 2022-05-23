using BusinessLogicServer.Networking.Orders;
using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public class OrderModel:IOrderModel
{
    private IOrderNetworking _orderNetworking;

    public OrderModel(IOrderNetworking orderNetworking)
    {
        _orderNetworking = orderNetworking;
    }


    public  async Task<IList<OrdersDTO>> GetAllOrdersAsync()
    {
       return  await _orderNetworking.GetAllOrdersAsync();
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await _orderNetworking.GetCustomer(orderUsername);
    }

    public async Task<IList<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        return await _orderNetworking.GetAllOrdersByStatusAsync(status);
    }

    public  async Task<IList<JoinDTO>> GetOrderLines(long id)
    {
        return await _orderNetworking.GetOrderLines(id);
    }

    public async Task UpdateOrderStatusAsync(long id, string status)
    {
        await _orderNetworking.UpdateOrderStatus(id, status);
    }
}