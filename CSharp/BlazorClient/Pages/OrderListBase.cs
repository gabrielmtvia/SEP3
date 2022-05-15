using BlazorClient.Services;
using BlazorClient.Services.OrderService;
using Microsoft.AspNetCore.Components;

namespace BlazorClient.Pages;

public class OrderListBase : ComponentBase
{
    [Inject]
    public IOrderService OrderService { get; set; }
    public IEnumerable<Order> Orders { get; set; }
    public Order OrderToCreate { set; get; }
    protected override async Task OnInitializedAsync()
    {
        OrderToCreate = new Order();
        Thread.Sleep(2000);
        Orders = (await OrderService.GetOrders()).ToList();
    }

    public async Task CreateOrder(Order o)
    {
        OrderService.CreateOrder(o);
        await OnInitializedAsync();
    }

    public async Task DeleteOrder(long id)
    {
        OrderService.DeleteOrder(id);
    }

    public void OnChange(ChangeEventArgs args)
    {
        OrderToCreate.Status = "D";
    }
}