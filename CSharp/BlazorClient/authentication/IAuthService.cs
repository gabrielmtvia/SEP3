using System.Security.Claims;

namespace BlazorClient.authentication;

public interface IAuthService
{
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Task<User?> GetUserFromCacheAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}