using BlazorClient.Services;
using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Pages;

public class OrderListBase : ComponentBase
{
    [Inject] public IOrderService OrderService { get; set; }
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
        OrderToCreate.delivered = args.Value.Equals("true");
    }
}