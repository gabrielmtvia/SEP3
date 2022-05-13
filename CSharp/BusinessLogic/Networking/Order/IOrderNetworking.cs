namespace BusinessLogicServer.Networking.Order;

public interface IOrderNetworking
{
    public Task<List<ModelClasses.Order>> GetAllOrdersAsync();
    public Task CreateOrderAsync(ModelClasses.Order order);
}