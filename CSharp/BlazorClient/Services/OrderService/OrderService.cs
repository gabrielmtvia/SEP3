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
        var orders = await httpClient.GetFromJsonAsync<ICollection<OrdersDTO>>("/Orders");
        return orders;
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return await httpClient.GetFromJsonAsync<UserDTO>($"/Orders/Customer/{orderUsername}");
    }

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return await httpClient.GetFromJsonAsync<ICollection<OrderLineDTO>>($"/Orders/Orderlines/{orderId}");
    }

    public async Task UpdateOrderStatusAsync(OrdersDTO order)
    {
        await httpClient.PostAsJsonAsync($"/Orders/UpdateStatus/",order);
    }

    public async Task<OrdersDTO> GetOrderById(long orderId)
    {
        OrdersDTO order = new();
        try
        {
            order = await httpClient.GetFromJsonAsync<OrdersDTO>($"/Orders/OrdersById/{orderId}");
        }
        catch (Exception e)
        {
            // Console.WriteLine(e);
        }

        return order!;
    }
}