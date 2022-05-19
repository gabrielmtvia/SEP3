using System.Security.Claims;

namespace BlazorClient.Services.UserService;

public interface IUserService
{
    Task<string?> GetUserAsync2(string username, string password);
  //  public Task<User?> GetUserAsync(string username, string password);

}