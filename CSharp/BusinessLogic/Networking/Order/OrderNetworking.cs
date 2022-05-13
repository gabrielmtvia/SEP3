using System.Text.Json;



namespace BusinessLogicServer.Networking.Order;

public class OrderNetworking : IOrderNetworking
{
    private OrderService.OrderServiceClient client;

    public OrderNetworking(OrderService.OrderServiceClient client)
    {
        this.client = client;
    }

    public async Task<List<ModelClasses.Order>> GetAllOrdersAsync()
    {
        var allOrdersAsync = await client.getAllOrdersAsync(new VoidMessage());

        var deserialize = JsonSerializer.Deserialize<List<ModelClasses.Order>>(allOrdersAsync.Order, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return deserialize;
    }

    public async Task CreateOrderAsync(ModelClasses.Order order)
    {
        var serialize = JsonSerializer.Serialize(order);
        await client.createOrderAsync(new OrderMessage()
        {
            Order = serialize
        });
    }
}