using System.Text;
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

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return await httpClient.GetFromJsonAsync<ICollection<OrderLineDTO>>($"/Orders/Orderlines/{orderId}");
    }

    public async Task UpdateOrderStatusAsync(OrdersDTO order)
    {
        UserDTO dummyUser = new UserDTO("userName", "firstName", "lastName", "email", "address", "phone", "role", "password");
        order.user = dummyUser; 
        order.username = "";
        string json = JsonSerializer.Serialize(order);
        StringContent content = new(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await httpClient.PostAsync("/Orders/UpdateStatus/", content);
        string reponseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {reponseContent}");
        }
    }

    public async Task<OrdersDTO> GetOrderById(long orderId)
    {
        OrdersDTO order = new();
        try
        {
            order = await httpClient.GetFromJsonAsync<OrdersDTO>($"/Orders/OrderById/{orderId}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return order!;
    }
}