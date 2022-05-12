using BusinessLogicServer.Service.CartService;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _service;

    public CartController(ICartService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<OrderLineDTO>>>> GetCartItemsAsync(long orderId)
    {
        var result = await _service.GetCartItems(orderId);
        return Ok(result);
    }

    [HttpPost]
    [Route("/addToCart")]
    public async Task AddToCartAsync(OrderLineDTO item)
    {
        Console.WriteLine(item.ToString());
        await _service.AddToCart(item);
        Console.WriteLine(item.ToString());
    }

    [HttpPost]
    [Route("/createOrder")]
    public async Task<long> CreateShoppingCart(OrderDTO orderDto)
    {
        return await _service.CreateOrder(orderDto);
    }

}