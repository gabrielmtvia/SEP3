using System.Security.Claims;
using ModelClasses;

namespace BlazorClient.Services.UserService;

public interface IUserService
{
    Task<string?> GetUserAsync(string username, string password);
  //  public Task<User?> GetUserAsync(string username, string password);

}