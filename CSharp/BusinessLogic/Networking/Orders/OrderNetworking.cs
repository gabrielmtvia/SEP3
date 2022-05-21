using BusinessLogicServer.Networking.DummyDataForTesting;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using ModelClasses;

namespace BusinessLogicServer.Networking.Orders;

public class OrderNetworking : IOrderNetworking
{
    private OrderService.OrderServiceClient client;
    private DummyOrdersRepository _dummyOrdersRepository = new();

    public OrderNetworking(OrderService.OrderServiceClient client)
    {
        this.client = client;
    }

    
    // THE LINES BELOW ARE THE IMPLEMENTATION FROM THE PROOF OF CONCEPT.
    // It's different from what we need now, because
    // 1) now we are using OrdersDTO.cs instead of Order.cs,
    // 2) We need to pass ICollection instead of List, because it's already implemented as such in Tier 1 and partly in Tier 2
    // List may by converted to IEnumerable simply by "equal sign". F.x. IEnumerableObject1 = ListObject1;

    // public async Task<List<Order>> GetAllOrdersAsync()
    // {
    //     var voidMessage = new VoidMessage();
    //     var allOrdersAsync = await client.getAllOrdersAsync(voidMessage);
    //
    //     var orderMessages = allOrdersAsync.Orders;
    //     var orders = new List<Order>();
    //     foreach (var orderMessage in orderMessages)
    //     {
    //         // create an order from orderMessage (solution)
    //         var toAdd = new Order
    //         {
    //             Id = orderMessage.Id,
    //             Amount = orderMessage.Amount,
    //             Status = orderMessage.Status,
    //             Description = orderMessage.Description
    //         };
    //         orders.Add(toAdd);
    //     }
    //
    //     return orders;
    // }

    public Task CreateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        // TODO: connection with gRPC service and fetching the data from database is to be implemented by Khaled.
        // Something like in the commented method above GetAllOrdersAsync()
        // until it's implemented properly, the below dummy repository serve for testing purposes.
        
        ICollection<OrdersDTO> orders = await _dummyOrdersRepository.GetOrdersByStatusAsync(status);
        return orders;
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        // TODO: connection with gRPC service and fetching the data from database is to be implemented by Khaled.
        // Something like in the commented method above GetAllOrdersAsync()
        // until it's implemented properly, the below dummy lines serve as an example.
        
        ICollection<OrdersDTO> orders = await _dummyOrdersRepository.GetAllOrdersAsync();
        return orders;
    }
}