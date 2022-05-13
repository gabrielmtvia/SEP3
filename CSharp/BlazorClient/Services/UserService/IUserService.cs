using System.Security.Claims;
using ModelClasses;

namespace BlazorClient.Services.UserService;

public interface IUserService
{
    public Task<User?> GetUserAsync(string username);

}