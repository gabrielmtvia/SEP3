using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicServer.Service.GenreService;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Genre>>>> GetGenresAsync()
    {
        var result = await _service.GetGenresAsync();
        return Ok(result);
    }
}