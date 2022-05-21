using ModelClasses;

namespace BusinessLogicServer.Models.Orders;

public interface IOrderModel
{
    // I commented the line below out, because I needed this method to be implemented differently, and I didn't see
    // any usage of it besides the proof of concept. If any problems, please contact @Tomasz G.
    // @Eliza and @Gabriel - if you guys think it's OK, then you can safely remove the comment together with the commented code.
    // see affected 2 other files: OrderController.cs, and OrderModel.cs 
    
    //public Task<List<Order>> GetAllOrdersAsync();
    
    public Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status);
    public Task<ICollection<OrdersDTO>> GetAllOrdersAsync();
    public Task CreateOrderAsync(Order order);
}