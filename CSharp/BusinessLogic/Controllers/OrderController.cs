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

    [HttpGet("/Orders/{status}")]
    public async Task<ActionResult<ICollection<OrdersDTO>>> GetOrdersByStatusAsync(string status)
    {
        try
        {
            ICollection<OrdersDTO> items = await model.GetOrdersByStatusAsync(status);
            return Ok(items);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("/Orders/")]
    public async Task<ActionResult<ICollection<OrdersDTO>>> GetAllOrdersAsync()
    {
        try
        {
            ICollection<OrdersDTO> items = await model.GetAllOrdersAsync();
            return Ok(items);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    // [HttpGet]
    // [Route("/Orders/")]
    // public async Task<ActionResult<ICollection<OrdersDTO>>> GetAllOrdersAsync()
    // {
    //     try
    //     {
    //         ICollection<OrdersDTO> items = await businessLogicDao.GetAllOrdersAsync();
    //         return Ok(items);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, e.Message);
    //     }
    // }


    // I commented the lines below out, because I needed this method to be implemented differently, and I didn't see
    // any usage of it on the day of 19th May 2021. It looks like it was used for the proof of concept only.
    // Anyway, now, a different implementation of it is necessary for Employee's Panel (generating list of orders).
    // If any problems, please reach out to me. Tomasz G.
    // @Eliza and @Gabriel - if you guys think it's OK, then you can safely remove the comment together with the commented code.
    // see affected 2 other files: IOrderModel.cs, and OrderModel.cs
    
    // [HttpGet]
    // public async Task<List<Order>> GetAllOrdersAsync()
    // {
    //     return await model.GetAllOrdersAsync();
    // }

    [HttpPost]
    public async Task<ActionResult> CreateOrderAsync(Order order)
    {
        await model.CreateOrderAsync(order);
        return Ok();
    }
}