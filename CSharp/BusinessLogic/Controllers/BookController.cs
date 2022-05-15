using BusinessLogicServer.Models.Orders;
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
    public async Task<ActionResult<ServiceResponse<Book>>> GetBookAsync(string isbn)
    {
        var result = await _service.GetBookAsync(isbn);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("genre/{genreUrl}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooksByGenre(string genreUrl)
    {
        var result = await _service.GetBooksByGenreAsync(genreUrl);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("search/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> SearchBooks(string searchText)
    {
        var result = await _service.SearchBooksAsync(searchText);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("searchsuggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBookSearchSuggestions(string searchText)
    {
        var result = await _service.GetBookSearchSuggestionsAsync(searchText);
        return Ok(result);
    }

}