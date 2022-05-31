using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicServer.Models.Genre;
//using BusinessLogicServer.Service.GenreService;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
  /*  private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Genre>>>> GetGenresAsync()
    {
        var result = await _service.GetGenresAsync();
        return Ok(result);
    }*/

  private IGenreModel _genreModel;

  public GenreController(IGenreModel genreModel)
  {
      _genreModel = genreModel;
  }
  
  
  
  [HttpPost]
  public async Task<ActionResult> AddGenre(Genre genre)
  {
      try
      {
          await _genreModel.AddGenre(genre);

          return Ok();
      }
      catch (Exception e)
      {
          return StatusCode(500, e.Message);
      }
  }
  
  [HttpGet]
  public async Task<List<Genre>> getAllGenre()
  {
     
         return await _genreModel.GetAllGenre();

         
      
      
  }
  
}