using Microsoft.AspNetCore.StaticFiles.Infrastructure;

namespace BusinessLogicServer.Networking.Orders;

public class OrderNetworking : IOrderNetworking
{
    private OrderService.OrderServiceClient client;

    public OrderNetworking(OrderService.OrderServiceClient client)
    {
        this.client = client;
    }


    public async Task<List<Order>> GetAllOrdersAsync()
    {
        var voidMessage = new VoidMessage();
        var allOrdersAsync = await client.getAllOrdersAsync(voidMessage);

        var orderMessages = allOrdersAsync.Orders;
        var orders = new List<Order>();
        foreach (var orderMessage in orderMessages)
        {
            // create an order from orderMessage (solution)
            var toAdd = new Order
            {
                Id = orderMessage.Id,
                Amount = orderMessage.Amount,
                Status = orderMessage.Status,
                Description = orderMessage.Description
            };
            orders.Add(toAdd);
        }

        return orders;
    }

    public Task CreateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }
}