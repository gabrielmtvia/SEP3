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

    public async Task<long> CreateOrder(OrderDTO orderDto)
    {
        if (OrderList.Contains(orderDto))
        {
            return Convert.ToInt64(OrderList.IndexOf(orderDto));
        }
        
        OrderList.Add(orderDto);
        
        return Convert.ToInt64(OrderList.IndexOf(orderDto));
    }

    public async Task AddToCart(OrderLineDTO item)
    {
        if(!ShoppingCart.Exists(i => i.Isbn == item.Isbn))
            ShoppingCart.Add(item);
        else
        {
            var toUpdate = ShoppingCart.Find(i => i.Isbn == item.Isbn);
            toUpdate.Quantity = item.Quantity;
        }

    }

    public async Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long serialOrder)
    {
        var response = new List<OrderLineDTO>();

        foreach (var orderLine in ShoppingCart)
        {
            if (orderLine.SerialOrder.Equals(serialOrder))
            {
                response.Add(orderLine);
            }
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
            Console.WriteLine("EMPTY ORDER LIST");
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
}