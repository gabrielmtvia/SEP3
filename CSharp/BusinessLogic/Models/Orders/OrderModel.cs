using BusinessLogicServer.Networking.Orders;

namespace BusinessLogicServer.Models.Orders;

public class OrderModel : IOrderModel
{
    
    private IOrderNetworking networking;

    public OrderModel(IOrderNetworking networking)
    {
        this.networking = networking;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
       return await networking.GetAllOrdersAsync();
    }

    public async Task CreateOrderAsync(Order order)
    {
        await networking.CreateOrderAsync(order);
    }
}