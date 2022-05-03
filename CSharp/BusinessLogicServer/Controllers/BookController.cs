using BusinessLogicServer.Model.Order;
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

    [HttpGet]
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await model.GetAllBooksAsync();
    }

}