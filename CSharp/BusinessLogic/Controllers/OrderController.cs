using BusinessLogicServer.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private IOrderModel model;

    public OrderController(IOrderModel model)
    {
        this.model = model;
    }

    [HttpGet]
    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await model.GetAllOrdersAsync();
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrderAsync(Order order)
    {
        await model.CreateOrderAsync(order);
        return Ok();
    }
}