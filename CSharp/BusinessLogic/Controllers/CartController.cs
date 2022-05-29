using BusinessLogicServer.Models.Cart;
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
    

}