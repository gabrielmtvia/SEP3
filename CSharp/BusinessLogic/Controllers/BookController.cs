using BusinessLogicServer.Models.Books;
using BusinessLogicServer.Models.Orders;
using BusinessLogicServer.Networking.Boo
using BusinessLogicServer.Service.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private IBookService _service;
    private IBookModel model;
    public BookController(IBookService service, IBookModel model)
    {
        _service = service;
        this.model = model;
    }

    [HttpPost]
    public async Task <ActionResult> AddBookAsync (Book book)
    {
        try
        {
            await model.AddBookAsync(book);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetAllBooksAsync()
    {
        try
        {
            var result = await _service.GetAllBooksAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{isbn}")]
    public async Task<ActionResult<ServiceResponse<Book>>> GetBookAsync(string isbn)
    {
        try
        {
            var result = await _service.GetBookAsync(isbn);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
       
    }
    
    [HttpGet]
    [Route("genre/{genreUrl}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooksByGenre(string genreUrl)
    {
        try
        {
            var result = await _service.GetBooksByGenreAsync(genreUrl);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("search/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> SearchBooks(string searchText)
    {
        try
        {
            var result = await _service.SearchBooksAsync(searchText);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("searchsuggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBookSearchSuggestions(string searchText)
    {
        try
        {
            var result = await _service.GetBookSearchSuggestionsAsync(searchText);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    }