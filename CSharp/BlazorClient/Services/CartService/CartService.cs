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
        Console.WriteLine(item.ToString());
        await _httpClient.PostAsJsonAsync("/addToCart", item);
    }

    public Task<ServiceResponse<List<OrderLineDTO>>> GetCartItems(long orderId)
    {
        var result = _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderLineDTO>>>($"/Cart?orderId={orderId}");
        return result;
    }

    public async Task<long> CreateOrder(OrderDTO order)
    {
        var response = await _httpClient.PostAsJsonAsync("/createOrder", order);
        var contents = await response.Content.ReadAsStringAsync();
        Console.WriteLine(contents);
        return Convert.ToInt64(contents);
    }
}