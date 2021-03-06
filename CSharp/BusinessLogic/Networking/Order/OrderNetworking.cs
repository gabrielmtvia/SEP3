using System.ComponentModel;
using ModelClasses;

namespace BusinessLogicServer.Networking.Order;

public class OrderNetworking:IOrderNetworking
{
    private OrderService.OrderServiceClient OrderServiceClient;

    public OrderNetworking(OrderService.OrderServiceClient orderServiceClient)
    {
        OrderServiceClient = orderServiceClient;
    }


    public async Task<List<OrdersDTO>> GetAllOrdersAsync()
    {
        
        var  orders = new List<OrdersDTO>();
        var allOrdersAsync =  await  OrderServiceClient.getAllOrdersAsync(new EmptyOrderMessage());
        var orderMessage = allOrdersAsync.Orders;
        foreach (var orderProto in orderMessage)
        {  
            var order1 = new OrdersDTO
            {
               
               id = orderProto.Id,
               date = Convert.ToDateTime(orderProto.Date),
               status = orderProto.Status,
               user = new UserDTO(orderProto.Username,orderProto.Firstname,orderProto.Lastname,orderProto.Address,orderProto.Phone,orderProto.Email)
               //,
               //UserDto = new UserDTO(orderProto.Username,orderProto.Firstname,orderProto.Lastname,orderProto.Email
              // ,orderProto.Address,orderProto.Phone) 

            };
            orders.Add(order1);
          Console.WriteLine(order1.date);
        }

        
        
        return orders;
        
    }

    public  async Task<UserDTO> GetCustomer(string orderUsername)
    {
        UserDTO? userDto;
        var Customerorder = await OrderServiceClient.getCustomerOrderAsync(new OrderUsername
        {
            Username = orderUsername
        });
        
        userDto = new UserDTO(Customerorder.Username, Customerorder.Firstname, Customerorder.Lastname,
            Customerorder.Email, Customerorder.Address, Customerorder.Phone);
        
        return userDto;
    }

    public async Task<List<OrdersDTO>> GetAllOrdersByStatusAsync(string status)
    {
        var  orders = new List<OrdersDTO>();
        var allOrdersAsync =  await  OrderServiceClient.getOrdersByStatusAsync(new OrdersByStatusMessage
        {
            Status = status
        });
        var orderMessage = allOrdersAsync.Orders;
        foreach (var orderProto in orderMessage)
        {  
            var order1 = new OrdersDTO
            {
               
                id = orderProto.Id,
                date = Convert.ToDateTime(orderProto.Date),
                status = orderProto.Status,
                user = new UserDTO(orderProto.Username,orderProto.Firstname,orderProto.Lastname,orderProto.Address,orderProto.Phone,orderProto.Email)
                //,
                //UserDto = new UserDTO(orderProto.Username,orderProto.Firstname,orderProto.Lastname,orderProto.Email
                // ,orderProto.Address,orderProto.Phone) 

            };
            orders.Add(order1);
            Console.WriteLine(order1.date);
        }

        
        
        return orders;
    }

    public async  Task<List<OrderLineDTO>> GetOrderLines(long id)
    {
         
        var  orderLines = new List<OrderLineDTO>();
        var allOrderLinesAsync =  await  OrderServiceClient.getOrderLineAsync(new OrderIDMessage
        {
            Id= id
        });
        var orderLineMessage = allOrderLinesAsync.OrderLineMessage;
        foreach (var orderLineProto in orderLineMessage)
        {  
            var orderline1 = new OrderLineDTO
            {  book = new Book(orderLineProto.Isbn,orderLineProto.Title,orderLineProto.Author,orderLineProto.Edition,orderLineProto.Description,orderLineProto.Url,orderLineProto.Price),SerialOrder = orderLineProto.Id,
                Isbn=orderLineProto.Isbn,Quantity = orderLineProto.Qte
             //  id=orderLineProto.Id,author = orderLineProto.Author, edition = orderLineProto.Edition,isbn=orderLineProto.Isbn
            //   ,description = orderLineProto.Description,price = orderLineProto.Price,qte = orderLineProto.Qte,title = orderLineProto.Title,url = orderLineProto.Url
               
               

            };
            orderLines.Add(orderline1);
            //Console.WriteLine(order1.date);
        }

        
        
        return orderLines;
    }

    public async Task UpdateOrderStatus(long id, string status)
    {
        await OrderServiceClient.updateOrderStatusAsync(new ChangeStatusOfOrder
        {
            Id = id,
            Status = status
        });
    }

    public async Task<List<OrdersDTO>> GetAllOrdersByUsername(string username)
    {
        var  orders = new List<OrdersDTO>();
        var allOrdersAsync =  await  OrderServiceClient.getAllOrdersByUserNameAsync(new OrderUsername
        {
           Username = username
        });
        var orderMessage = allOrdersAsync.Orders;
        foreach (var orderProto in orderMessage)
        {  
            var order1 = new OrdersDTO
            {
               
                id = orderProto.Id,
                date = Convert.ToDateTime(orderProto.Date),
                status = orderProto.Status,
                user = new UserDTO(orderProto.Username,orderProto.Firstname,orderProto.Lastname,orderProto.Address,orderProto.Phone,orderProto.Email)
                
            };
            orders.Add(order1);
            Console.WriteLine(order1.date);
        }

        
        
        return orders;
        
    }
}