using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Models.Register;

public interface IRegisterModel
{
    public Task CreateUser(UserDTO userDto);
    // public Task<ActionResult<string>> getRole(User user);
    public Task<string> GetRole(string userName, string password);
}