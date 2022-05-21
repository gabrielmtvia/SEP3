using ModelClasses;

namespace BusinessLogicServer.Networking.DummyDataForTesting;

public class DummyOrdersRepository
{
    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        ICollection<OrdersDTO> orders = Array.Empty<OrdersDTO>();
        if (status.Equals("CONFIRMED"))
        {
            orders = new []
            {
                new OrdersDTO(1, DateTime.Now, "CONFIRMED", "customer1"),
                new OrdersDTO(2, DateTime.Now.AddDays(-1), "CONFIRMED", "customer2"),
                new OrdersDTO(3, DateTime.Now.AddDays(-2), "CONFIRMED", "customer3")
            };    
        }
        else if (status.Equals("DISPATCHED"))
        {
            orders = new []
            {
                new OrdersDTO(3, DateTime.Now.AddDays(-3), "DISPATCHED", "customer4"),
                new OrdersDTO(3, DateTime.Now.AddDays(-4), "DISPATCHED", "customer5")
            };
        }

        return orders;
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        ICollection<OrdersDTO> orders = new []
        {
            new OrdersDTO(1, DateTime.Now, "CONFIRMED", "customer1"),
            new OrdersDTO(2, DateTime.Now.AddDays(-1), "CONFIRMED", "customer2"),
            new OrdersDTO(3, DateTime.Now.AddDays(-2), "CONFIRMED", "customer3"),
            new OrdersDTO(3, DateTime.Now.AddDays(-3), "DISPATCHED", "customer4"),
            new OrdersDTO(3, DateTime.Now.AddDays(-4), "DISPATCHED", "customer5")
        };
        return orders;
    }
}