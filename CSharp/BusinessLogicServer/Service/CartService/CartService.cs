namespace BusinessLogicServer.Service.CartService;

public class CartService : ICartService
{
    public List<OrderLineDTO> ShoppingCart { get; set; } = new List<OrderLineDTO>();
    public List<OrderDTO> OrderList { get; set; } = new List<OrderDTO>();

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
}