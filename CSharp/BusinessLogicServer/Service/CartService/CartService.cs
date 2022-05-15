using BusinessLogicServer.Service.BookService;

namespace BusinessLogicServer.Service.CartService;

public class CartService : ICartService
{
    public List<OrderLineDTO> ShoppingCart { get; set; } = new List<OrderLineDTO>();
    public List<OrderDTO> OrderList { get; set; } = new List<OrderDTO>();

    private IBookService BookService;

    public CartService(IBookService bookService)
    {
        BookService = bookService;
        
    }

    public async Task<ServiceResponse<long>> CreateOrder(OrderDTO orderDto)
    {
        Console.WriteLine(orderDto.Status + " " + orderDto.Date + " "+ orderDto.Username);
        if (OrderList.Exists(o=>o.Username.Equals(orderDto.Username)&&o.Date.Equals(orderDto.Date)&&o.Status.Equals(orderDto.Status)))
        {
            Console.WriteLine("Index of order is " + Convert.ToInt64(OrderList.FindIndex(o=>o.Username.Equals(orderDto.Username)&&o.Date.Equals(orderDto.Date)&&o.Status.Equals(orderDto.Status))));
            return new ServiceResponse<long>()
            {
                Data = Convert.ToInt64(OrderList.FindIndex(o=>o.Username.Equals(orderDto.Username)&&o.Date.Equals(orderDto.Date)&&o.Status.Equals(orderDto.Status)))
            };
        }
        
        OrderList.Add(orderDto);
        Console.WriteLine("Index of order is " + Convert.ToInt64(OrderList.FindIndex(o=>o.Username.Equals(orderDto.Username)&&o.Date.Equals(orderDto.Date)&&o.Status.Equals(orderDto.Status))));
        var order = OrderList.Find(o=>o.Username.Equals(orderDto.Username)&&o.Date.Equals(orderDto.Date)&&o.Status.Equals(orderDto.Status));
        if(order != null) order.SerialOrder = Convert.ToInt64(OrderList.FindIndex(o =>
            o.Username.Equals(orderDto.Username) && o.Date.Equals(orderDto.Date) && o.Status.Equals(orderDto.Status)));
        return new ServiceResponse<long>()
        {
            Data = Convert.ToInt64(OrderList.FindIndex(o=>o.Username.Equals(orderDto.Username)&&o.Date.Equals(orderDto.Date)&&o.Status.Equals(orderDto.Status))),
            Message = "New shopping cart created"
        };
    }

    public async Task AddToCart(OrderLineDTO item)
    {
        if(!ShoppingCart.Exists(i => i.Isbn == item.Isbn && i.SerialOrder == item.SerialOrder))
            ShoppingCart.Add(item);
        else
        {
            var toUpdate = ShoppingCart.Find(i => i.Isbn == item.Isbn && i.SerialOrder == item.SerialOrder);
            toUpdate.Quantity = item.Quantity;
        }

    }

    public async Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long serialOrder)
    {
        Console.WriteLine("GetCartItems in serialOrder" + serialOrder);
        var response = new List<OrderLineDTO>();

        foreach (var orderLine in ShoppingCart)
        {
            if (orderLine.SerialOrder == serialOrder)
            {
                response.Add(orderLine);
                Console.WriteLine("Adding to the shopping cart" + orderLine.Isbn+ orderLine.SerialOrder);
            }
            Console.WriteLine("Contents of the shopping cart" + orderLine.Isbn + " Order number " + orderLine.SerialOrder);
        }

        if (response.Count != 0)
        {
            Console.WriteLine(response.ToString());
            return new ServiceResponse<List<OrderLineDTO>>()
            {
                Data = response
            };
        }
        else
        {
            Console.WriteLine("EMPTY ORDER LIST " + serialOrder);
            return new ServiceResponse<List<OrderLineDTO>>()
            {
                Message = "Incorrect order number",
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<ShoppingCartItem>>> GetShoppingCart(long serialOrder)
    {
        var shoppingCart = new List<ShoppingCartItem>();

        foreach (var item in ShoppingCart)
        {
            if (item.SerialOrder == serialOrder)
            {
                var book = BookService.GetBookAsync(item.Isbn);
                shoppingCart.Add(
                    new ShoppingCartItem
                    {
                        Author = book.Result.Data.Author,
                        ImageUrl = book.Result.Data.ImageUrl,
                        Isbn = book.Result.Data.Isbn,
                        Price = book.Result.Data.Price,
                        Quantity = item.Quantity.Value,
                        Title = book.Result.Data.Title
                    });
            }
        }

        if (shoppingCart.Count != 0)
        {
            return new ServiceResponse<List<ShoppingCartItem>>
            {
                Data = shoppingCart
            };  
        }
        
        return new ServiceResponse<List<ShoppingCartItem>>
        {
            Message = "Shopping cart empty",
            Success = false,
            Data = shoppingCart
        };

    }

    public async Task<ServiceResponse<long>> GetSerialOrder(string username, string date, OrderStatus status)
    {
        var result = OrderList.Find(o => o.Username.Equals(username) && o.Date.Equals(date) && o.Status == status);
        if (result != null)
        {
            Console.WriteLine("Get serial order method " +result.SerialOrder + result.Username + result.Date + result.Status);
            return new ServiceResponse<long>()
            {
                Data = result.SerialOrder
            };

        }

        
        return new ServiceResponse<long>()
        {
            Message = "Order Not Found",
            Success = false,
        };
    }

    public async Task<ServiceResponse<long>> CheckOut(long serialOrder)
    {
        Console.WriteLine("trying to find serial order "+ serialOrder);
        if (ShoppingCart.FindAll(o => o.SerialOrder == serialOrder).Count == 0)
        {
            return new ServiceResponse<long>()
            {
                Success = false,
                Message = "Shopping cart is empty, please add a product first before checkout"
            };
        } 
        else
        {
            var order = OrderList.Find(o => o.SerialOrder == serialOrder);
            Console.WriteLine("trying to confirm order number " + serialOrder);
            if(order!=null) order.Status = OrderStatus.Confirmed;
            foreach (var item in OrderList)
            {
                Console.WriteLine("inside orderlist" + item.SerialOrder + item.Date + item.Username + item.Status);
            }
            return new ServiceResponse<long>()
            {
                Data = serialOrder,
                Message = "The order has been confirmed"
            };
        }
    }

    public async Task RemoveProductFromCartAsync(OrderLineDTO item)
    {
        
        Console.WriteLine("Trying to remove" + item.Isbn +" "+ item.Quantity +" "+ item.SerialOrder);
        
        Console.WriteLine("before deleting");
        foreach (var i in ShoppingCart)
        {
            Console.WriteLine(i.SerialOrder + " " + i.Isbn + " " + i.Quantity);
        }
        
        //ShoppingCart.Remove(item);
        ShoppingCart.RemoveAt(ShoppingCart.FindIndex(i=>i.Isbn == item.Isbn && i.SerialOrder == item.SerialOrder && i.Quantity == item.Quantity));
        
        Console.WriteLine("after deleting");
        foreach (var i in ShoppingCart)
        {
            Console.WriteLine(i.SerialOrder + " " + i.Isbn + " " + i.Quantity);
        }

    }
}