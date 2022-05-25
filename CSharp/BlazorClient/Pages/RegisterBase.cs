using System.Security.Claims;
using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using ModelClasses;

namespace BlazorClient.Pages;

public class RegisterBase : ComponentBase
{
    [Inject]
    public IRegisterService _registerService { get; set; }
    [Inject] public IAuthService iAuthService { get; set; }
    [Inject] public IUserService IuserService{ get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] private IJSRuntime JsRuntime { get; set; }
    
    
    [CascadingParameter]
    
    public Task<AuthenticationState> AuthState { get; set; }
    public IEnumerable<Claim> claims;
    public ClaimsPrincipal user; 
    public UserDTO userDto = new();
   
   
     
  

    private string? errorLabel = String.Empty;

    public async Task CreateAccount()
    {
            errorLabel = "";
      
           await _registerService.createUser(userDto);
           alertMsg();
          
    }
    
    protected override async Task OnInitializedAsync()
    {
        AuthenticationState authState = await AuthState;
        user = authState.User;
        if (user.Identity == null) return;

        claims = user.Claims;
    }
    
    public void alertMsg()
    {
        // string s = IuserService.GetUserAsync2(user)
        if (userDto.userName !=null && userDto.firstName !=null && userDto.lastName !=null && userDto.phone !=null && userDto.email !=null && userDto.address !=null && userDto.password !=null)
        {
            Thread.Sleep(500);
            Alert("You have created account Successfully");
            if (user.Identity == null)
            {
                NavigationManager.NavigateTo("/Login");
            }
            else
            {
                NavigationManager.NavigateTo("/ListOfEmployee");
            }
        
        }
      
    }

    private async Task Alert(string msg)
    {
        await JsRuntime.InvokeAsync<object>("Alert", msg);
    }
}