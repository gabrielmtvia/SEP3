using System.Security.Claims;
using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;

namespace BlazorClient;

public class RegisterBase : ComponentBase
{
  
    [Inject] public IAuthService iAuthService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [CascadingParameter]
    
    public Task<AuthenticationState> AuthState { get; set; }
    public IEnumerable<Claim> claims;
    public ClaimsPrincipal user; 
    public UserDTO userDto = new();

    public IRegisterService _registerService;
   
     
  

    private string? errorLabel = String.Empty;

    protected  void CreateAccount()
    {
        errorLabel = "";
        try
        {

            _registerService.createUser(userDto);
            
            Console.WriteLine("just checking in registration" + userDto.userName);
            Console.WriteLine("just checking in registration" + userDto.phone);
        
          
        }
        catch (Exception e)
        {
            errorLabel = $"Error: {e.Message}";

        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        AuthenticationState authState = await AuthState;
        user = authState.User;
        if (user.Identity == null) return;

        claims = user.Claims;
    }
}