using BusinessLogicServer.Models.Register;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    
    
    private IRegisterModel _registerModelmodel;


    
    public RegisterController(IRegisterModel _registerModelmodel)
    {
        this._registerModelmodel = _registerModelmodel;
    }
    
    
    
    
      
    [HttpPost]
    public async Task<ActionResult> createUser(UserDTO userDto)
    {
        try
        {
            await _registerModelmodel.CreateUser(userDto);

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
       
    
    [HttpGet]
    public async Task<ActionResult<string>> GetRole( string userName, string password)
    {
        try
        {
            return await _registerModelmodel.GetRole(userName,password);

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/ListOfUsersByRole")]
    public async Task<List<UserDTO>> GetUsersByRole(string role)
    {
        return await _registerModelmodel.GetUsersByRole(role);
    }

    [HttpDelete]
    [Route("{username}")]
    public async Task DeleteUser(string username)
    {
        await _registerModelmodel.DeleteUser(username);
    }
    
}