using BusinessLogicServer.Model.Order;
using BusinessLogicServer.Service.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetAllBooksAsync()
    {
        var result = await _service.GetAllBooksAsync();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{isbn}")]
    public async Task<ActionResult<ServiceResponse<Book>>> GetBookAsync(long isbn)
    {
        var result = await _service.GetBookAsync(isbn);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooksByCategory(string categoryUrl)
    {
        var result = await _service.GetBooksByCategoryAsync(categoryUrl);
        return Ok(result);
    }

}