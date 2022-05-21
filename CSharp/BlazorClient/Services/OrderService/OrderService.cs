using System.Net.Http.Headers;
using System.Text.Json;
using ModelClasses;

namespace BlazorClient.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly HttpClient httpClient;

    public OrderService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        return await httpClient.GetFromJsonAsync<ICollection<OrdersDTO>>($"/Orders/{status}");
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        return await httpClient.GetFromJsonAsync<ICollection<OrdersDTO>>("/Orders");
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await httpClient.GetFromJsonAsync<UserDTO>($"/Orders/Customer/{orderUsername}");
    }

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return await httpClient.GetFromJsonAsync<ICollection<OrderLineDTO>>($"/Orders/Orderlines/{orderId}");
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await httpClient.GetFromJsonAsync<Order[]>("/Order");
    }

    public async void CreateOrder(Order o)
    {
        var json = JsonSerializer.Serialize(o);
        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        await httpClient.PostAsync("/Order", byteContent);
    }

    public async void DeleteOrder(long orderId)
    {
        await httpClient.DeleteAsync($"/deleteOrder/{orderId}");
    }
}