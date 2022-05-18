using System.Security.Claims;

namespace BlazorClient.Services.UserService;

public interface IUserService
{
    public Task<User?> GetUserAsync(string username, string password);

}