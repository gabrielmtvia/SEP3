using BlazorClient.Services.BookService;
using BlazorClient.Services.CartService;
using BlazorClient.Services.OrderService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;
using SixLabors.ImageSharp.Processing;

namespace BlazorClient.Pages;

public class CustomerOrderHistoryBase : ComponentBase
{
    [Inject] private IOrderService orderService { get; set; }
    public string info = String.Empty;
    public string searchText = string.Empty;
    protected ElementReference searchInput;
    public string errorLabel = "";
    public string editErrorLabel = string.Empty;
    public string? orderStatusFilter;
    public ICollection<OrdersDTO> ordersToShow;
    public bool doShowFilters;
    public bool showModalWithOrderDetails;
    public UserDTO customerToView = new();
    public List<OrderLineDTO> orderlinesToView = new List<OrderLineDTO>();
    public string Username = string.Empty;
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }


    protected override async Task OnInitializedAsync()
    {
        Username = authenticationStateTask.Result.User.Identity.Name;
        OpenCloseFilters();
        orderStatusFilter = "All";
        await ApplyFilters();
    }
    

    public async Task OpenCloseFilters()
    {
        doShowFilters = !doShowFilters;
        if (!doShowFilters)
        {
            orderStatusFilter = "All";
            await ApplyFilters();
        }
    }
    
    public async Task UpdateOrderStatusFilter(ChangeEventArgs args)
    {
        searchText = "";
        orderStatusFilter = (string) args.Value;
        await ApplyFilters();
    }
    
    public async Task ApplyFilters()
    {
        try
        {
            if (orderStatusFilter!.Equals("All"))
            {
                var allOrders = await orderService.GetAllOrdersByUsernameAsync(Username);
                ordersToShow = allOrders.ToList();
            }
            else
            {
                var allOrders = await orderService.GetAllOrdersByUsernameAsync(Username);
                ordersToShow = new List<OrdersDTO>();
                foreach (var order in allOrders)
                {
                    if (order.status.Equals(orderStatusFilter))
                    {
                        ordersToShow.Add(order);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async Task HideOrderDetails()
    {
        customerToView = new UserDTO();
        orderlinesToView = new List<OrderLineDTO>();
        showModalWithOrderDetails = false;
    }

    public async Task ShowOrderDetails(OrdersDTO order)
    {
        customerToView = order.user;
        var response = await orderService.GetOrderLines(order.id);
        orderlinesToView = response.ToList();
        showModalWithOrderDetails = true;
    }

    public async Task SearchForAnOrderByID()
    {
        ordersToShow = new List<OrdersDTO>();
        long orderId = 0;
        try
        {
            orderId = Int64.Parse(searchText);
        }
        catch (Exception e)
        {
            errorLabel = "The order number is wrong.";
            Console.WriteLine(e);
        }

        var order = await orderService.GetOrderById(orderId);
        if (order == null || order.status == null)
        {
            info = "No order with the ID: " + searchText;
        }
        else if(order.user.userName.Equals(Username))
        {
            ordersToShow.Add(order);    
        }
        else
        {
            info = "No order with the ID: " + searchText;
        }
    }
}