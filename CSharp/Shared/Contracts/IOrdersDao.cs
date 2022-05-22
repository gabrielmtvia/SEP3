namespace ModelClasses.Contracts;

public interface IOrdersDao
{
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
}