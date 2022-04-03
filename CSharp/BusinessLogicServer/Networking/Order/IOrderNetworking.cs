namespace BusinessLogicServer.Networking.Order;

public interface IOrderNetworking
{
    public Task<List<ModelClasses.Order>> GetAllOrdersAsync();
}