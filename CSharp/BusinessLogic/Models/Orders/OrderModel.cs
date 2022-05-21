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
    
    // I commented the lines below out, because I needed this method to be implemented differently, and I didn't see
    // any usage of it on the day of 19th May 2021. It looks like it was used for the proof of concept only.
    // Anyway, now, a different implementation of it is necessary for Employee's Panel (generating list of orders).
    // If any problems, please reach out to me. Tomasz G.
    // @Eliza and @Gabriel - if you guys think it's OK, then you can safely remove the comment together with the commented code.
    // see affected 2 other files: OrderController.cs, and IOrderModel.cs 

    // public async Task<CartList<Order>> GetAllOrdersAsync()
    // {
    //    return await networking.GetAllOrdersAsync();
    // }

    public async Task CreateOrderAsync(Order order)
    {
        await networking.CreateOrderAsync(order);
    }
}