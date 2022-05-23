using BusinessLogicServer.Models.Books;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
   
    private IBookModel model;
    public BookController(IBookModel model)
    {
        
        this.model = model;
    }

    [HttpPost]
    public async Task<ActionResult> AddBookAsync (Book book)
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
    public async Task<ActionResult<List<Book>>> GetAllBooksAsync()
    {
        try
        {
            var result = await model.GetAllBooksAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("{isbn}")]
    public async Task<ActionResult<Book>> GetBookAsync(string isbn)
    {
        try
        {
            var result = await model.GetBookByIsbnAsync(isbn);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
       
    }

    // [HttpGet]
    // [Route("search/{searchText}")]
    // public async Task<ActionResult<ServiceResponse<List<Book>>>> SearchBooks(string searchText)
    // {
    //     var result = await _service.SearchBooksAsync(searchText);
    //     return Ok(result);
    // }
    //
    // [HttpGet]
    // [Route("searchSuggestions/{searchText}")]
    // public async Task<ActionResult<ServiceResponse<List<string>>>> GetBookSearchSuggestions(string searchText)
    // {
    //     var result = await _service.GetBookSearchSuggestionsAsync(searchText);
    //     return Ok(result);
    // }

    }