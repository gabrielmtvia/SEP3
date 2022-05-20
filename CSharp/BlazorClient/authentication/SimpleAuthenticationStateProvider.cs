using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorClient.authentication;

public class SimpleAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService iAuthService;

    public SimpleAuthenticationStateProvider(IAuthService iAuthService)
    {
       this.iAuthService = iAuthService;
       iAuthService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await iAuthService.GetAuthAsync();
        return await Task.FromResult(new AuthenticationState(principal));
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
    
    
}