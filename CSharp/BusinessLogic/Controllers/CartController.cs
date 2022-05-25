using BusinessLogicServer.Models.Cart;
using BusinessLogicServer.Service.CartService;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartModel _model;

    public CartController(ICartModel model)
    {
        _model = model;
    }

    [HttpPost]
    public async Task<ActionResult> AddCartAsync(CartLineDTO cartLineDto)
    {
        try
        {
            Console.WriteLine(cartLineDto.username+"**************************************");
            await _model.AddCartAsync(cartLineDto);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    /*[HttpGet]
    [Route("{orderId}")]
    public async Task<ActionResult<ServiceResponse<List<OrderLineDTO>>>> GetCartItemsAsync(long orderId)
    {
        var result = await _service.GetCartItems(orderId);
        return Ok(result);
    }

    [HttpGet]
    [Route("/getShoppingCart/{serialOrder}")]
    public async Task<ActionResult<ServiceResponse<List<ShoppingCartItem>>>> GetShoppingCart(long serialOrder)
    {
        var result = await _service.GetShoppingCart(serialOrder);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("/getAllOrders/{username}")]
    public async Task<ActionResult<ServiceResponse<List<OrderDTO>>>> GetAllOrdersByUsernameAsync(string username)
    {
        var result = await _service.GetAllOrdersByUsernameAsync(username);
        return Ok(result);
    }
    

    [HttpPost]
    [Route("/addToCart")]
    public async Task<ActionResult> AddToCartAsync(OrderLineDTO item)
    {
        Console.WriteLine(item.ToString());
        await _service.AddToCart(item);
        Console.WriteLine(item.ToString());
        return Ok();
    }
    
    [HttpPost]
    [Route("/removeProductFromCart")]
    public async Task<ActionResult> RemoveProductFromCartAsync(OrderLineDTO item)
    {
        await _service.RemoveProductFromCartAsync(item);
        return Ok();
    }

    [HttpPost]
    [Route("/createOrder")]
    public async Task<ActionResult<ServiceResponse<long>>> CreateShoppingCart(OrderDTO orderDto)
    {
        return Ok(await _service.CreateOrder(orderDto));
    }

    [HttpPost]
    [Route("/getSerialOrder")]
    public async Task<ActionResult<ServiceResponse<long>>> GetSerialOrder(UsernameDateStatus usernameDateStatus)
    {
        var result = await _service.GetSerialOrder(usernameDateStatus.Username, usernameDateStatus.Date, usernameDateStatus.Status);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("/checkOut")]
    public async Task<ActionResult<ServiceResponse<long>>> CheckOut([FromBody]long serialOrder)
    {
        Console.WriteLine("Controller received serial order" + serialOrder);
        var result = await _service.CheckOut(serialOrder);
        return Ok(result);
    }*/

}