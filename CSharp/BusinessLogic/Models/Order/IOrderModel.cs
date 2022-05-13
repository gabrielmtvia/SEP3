namespace BusinessLogicServer.Model.Order;

public interface IOrderModel
{
    public Task<List<ModelClasses.Order>> GetAllOrdersAsync();
    public Task CreateOrderAsync(ModelClasses.Order order);
}