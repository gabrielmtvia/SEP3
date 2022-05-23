using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicServer.Models.Genres;
using Microsoft.AspNetCore.Mvc;
namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private IGenreModel model;
    
    public GenreController(IGenreModel model)
     {
        this.model = model;
    }

    [HttpPost]
    public async Task<ActionResult> AddGenreAsync(Genre genre)
    {
        try
        {
            await model.AddGenreAsync(genre);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
            
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Genre>>> GetAllGenreAsync()
    {
        try
        {
            var result = await model.GetAllGenresAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{type}")]
    public async Task<ActionResult<Genre>> DeleteGenreAsync(String type)
    {
        try
        { 
            await model.DeleteGenreAsync(type);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
      
    }



}