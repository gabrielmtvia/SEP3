using BlazorClient.Model;
using BlazorClient.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorClient.Pages;

public class OrderListBase : ComponentBase
{
    [Inject] public IOrderService OrderService { get; set; }
    public IEnumerable<Order> Orders { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Thread.Sleep(2000);
        Orders = (await OrderService.GetOrders()).ToList();
    }

    public void CreateOrder(Order o)
    {
        OrderService.CreateOrder(o);
    }
}