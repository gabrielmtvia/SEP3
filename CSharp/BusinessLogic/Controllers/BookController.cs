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
            var result = await model.GetBookByIsbn(isbn);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
       
    }
    [HttpGet]
    [Route("genre/{genre}")]
    public async Task<ActionResult<List<Book>>> GetAllBooksByGenreAsync(string genre)
    {
        try
        {
            var result = await model.GetBookByGenreAsync(genre);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("title/{title}")]
    public async Task<ActionResult<List<Book>>> GetAllBooksByTitleAsync(string title)
    {
        try
        {
            var result = await model.GetBookByTitleAsync(title);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("author/{author}")]
    public async Task<ActionResult<List<Book>>> GetAllBooksByAuthorAsync(string author)
    {
        try
        {
            var result = await model.GetBookByAuthorAsync(author);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{isbn}")]
    public async  Task <ActionResult> DeleteBookByIsbn(string isbn)
    {
        try
        {
            await model.DeleteBookByIsbn(isbn);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}