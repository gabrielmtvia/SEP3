namespace BusinessLogicServer.Model.Order;

public interface IOrderModel
{
    public Task<List<ModelClasses.Order>> GetAllOrdersAsync();
}