using BusinessLogicServer.Models.Books;

using Microsoft.AspNetCore.Mvc;

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
    /*
    [HttpGet]
    [Route("genre/{genreUrl}")]
    public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooksByGenre(string genreUrl)
    {
        try
        {
            var result = await model.GetBooksByGenreAsync(genreUrl);
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
            var result = await model.SearchBooksAsync(searchText);
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
            var result = await model.GetBookSearchSuggestionsAsync(searchText);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    } */

    }