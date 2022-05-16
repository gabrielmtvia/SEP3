namespace BlazorClient.Services.CartService;

public class CartService : ICartService
{
    public event Action? OnChange;

    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddToCart(OrderLineDTO item)
    {
        // var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderLineDTO>>>($"/Cart/{item.SerialOrder}");
        // if (result != null && result.Data != null)
        // {
        //     var orderLine = result.Data.Find(o => o.Isbn == item.Isbn);
        //     if (orderLine != null)
        //     {
        //         item.Quantity += orderLine.Quantity;
        //     }
        // }

        await _httpClient.PostAsJsonAsync("/addToCart", item);
        OnChange?.Invoke();

    }

    public Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long orderId)
    {
        var result = _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderLineDTO>>>($"/Cart/{orderId}");
        return result;
    }

    public async Task<ServiceResponse<long>> CreateOrder(OrderDTO order)
    {
        var response = await _httpClient.PostAsJsonAsync("/createOrder", order);
        var contents = await response.Content.ReadFromJsonAsync<ServiceResponse<long>>();
        return contents;
    }

    public Task<ServiceResponse<List<ShoppingCartItem>>> GetShoppingCart(long serialOrder)
    {
        var result =
            _httpClient.GetFromJsonAsync<ServiceResponse<List<ShoppingCartItem>>>($"/getShoppingCart/{serialOrder}");
        return result;
    }

    public async Task<ServiceResponse<long>> GetSerialOrder(UsernameDateStatus usernameDateStatus)
    {
        var result = await _httpClient.PostAsJsonAsync("/getSerialOrder", usernameDateStatus);

        var response = result.Content.ReadFromJsonAsync<ServiceResponse<long>>().Result;

        return response;
    }

    public async Task<ServiceResponse<long>> CheckOut(long serialOrder)
    {
        var result = await _httpClient.PostAsJsonAsync("/checkOut", serialOrder);
        var response = result.Content.ReadFromJsonAsync<ServiceResponse<long>>().Result;
        OnChange?.Invoke();
        return response;
    }

    public async Task RemoveProductFromCart(OrderLineDTO item)
    {
       await _httpClient.PostAsJsonAsync("/removeProductFromCart", item);
       OnChange?.Invoke();
    }

    public async Task<ServiceResponse<List<OrderDTO>>> GetAllOrdersByUsernameAsync(string username)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderDTO>>>($"/getAllOrders/{username}");
        if(result != null)
            return result;
        
        return new ServiceResponse<List<OrderDTO>>()
        {
            Success = false,
            Message = "Network error"
        };
    }
}