using BusinessLogicServer.Model.Order;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<List<ModelClasses.Order>> GetAllOrdersAsync()
    {
        return await model.GetAllOrdersAsync();
    }
}