using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicServer.Networking.Order;

namespace BusinessLogicServer.Model.Order;

public class OrderModel : IOrderModel
{
    private IOrderNetworking networking;

    public OrderModel(IOrderNetworking networking)
    {
        this.networking = networking;
    }

    public async Task<List<ModelClasses.Order>> GetAllOrdersAsync()
    {
       return await networking.GetAllOrdersAsync();
    }

    public async Task CreateOrderAsync(ModelClasses.Order order)
    {
        await networking.CreateOrderAsync(order);
    }
}