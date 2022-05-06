using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategoriesAsync()
    {
        var result = await _service.GetCategoriesAsync();
        return Ok(result);
    }
}