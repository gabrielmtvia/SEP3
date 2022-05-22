using BusinessLogicServer.Networking.DummyDataForTesting;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using ModelClasses;

namespace BusinessLogicServer.Networking.Orders;

public class OrderNetworking : IOrderNetworking
{
    // TODO: connection with gRPC service and fetching the data from database is to be implemented by Khaled.
    // Something like in the commented method GetAllOrdersAsync()
    // until it's implemented properly, the below dummy repository serve for testing purposes.
    // My idea was to simply swap "dummyRepo" with "client", once the gRPC client is implemented.
    // But of course, the final decision of how to implement from here to Tier 3 is left to Khaled.

    private OrderService.OrderServiceClient client;
    private DummyRepositoryDao dummyRepo;

    public OrderNetworking(OrderService.OrderServiceClient client, DummyRepositoryDao dummyRepo)
    {
        this.client = client;
        this.dummyRepo = dummyRepo;
    }

    
    // THE LINES BELOW ARE THE IMPLEMENTATION FROM THE PROOF OF CONCEPT.
    // It's different from what we need now, because now we are using OrdersDTO.cs instead of Order.cs,

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
    
    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        ICollection<OrdersDTO> orders = await dummyRepo.GetOrdersByStatusAsync(status);
        return orders;
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        ICollection<OrdersDTO> orders = await dummyRepo.GetAllOrdersAsync();
        return orders;
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await dummyRepo.GetCustomer(orderUsername);
    }

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return await dummyRepo.GetOrderLines(orderId);
    }

    public async Task UpdateOrderStatusAsync(long orderId, string orderStatus)
    {
        await dummyRepo.UpdateOrderStatusAsync(orderId, orderStatus);
    }
}