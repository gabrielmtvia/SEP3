//using BusinessLogicServer.Models.Orders;

using BusinessLogicServer.Models.Order;
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
            ICollection<OrdersDTO> items = await model.GetAllOrdersByStatusAsync(status);
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
    
    [HttpGet("/Orders/Customer/{orderUsername}")]
    public async Task<ActionResult<UserDTO>> GetCustomer(string orderUsername)
    {
        try
        {
            UserDTO customer = await model.GetCustomer(orderUsername);
            return Ok(customer);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("/Orders/Orderlines/{orderId}")]
    public async Task<ActionResult<ICollection<OrderLineDTO>>> GetOrderLines(long orderId)
    {
        try
        {
            ICollection<OrderLineDTO> items = await model.GetOrderLines(orderId);
            return Ok(items);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("/Orders/UpdateStatus/")]
    public async Task<ActionResult> UpdateOrderStatusAsync([FromBody] OrdersDTO order)
    {
        {
            try
            {
                await model.UpdateOrderStatus(order.id, order.status);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
    
    [HttpGet("/OrdersUser/User/{orderUsername}")]
    public async Task<ActionResult<ICollection<OrdersDTO>>> GetAllOrdersByUsername(string orderUsername)
    {
        try
        {
            ICollection<OrdersDTO> allOrdersByUsername = await model.GetAllOrdersByUsername(orderUsername);
            return Ok(allOrdersByUsername);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("/Orders/OrderById/{orderId}")]
    public async Task<ActionResult<OrdersDTO>> getOrderById(long orderId)
    {
        try
        {
            OrdersDTO order = await model.GetOrderById(orderId);
            return Ok(order);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}