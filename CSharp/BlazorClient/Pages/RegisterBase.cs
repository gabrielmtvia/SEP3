using System.Security.Claims;
using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using ModelClasses;

namespace BlazorClient.Pages;

public class RegisterBase : ComponentBase
{
    [Inject] public IRegisterService _registerService { get; set; }
    [Inject] public IAuthService iAuthService { get; set; }
    [Inject] public IUserService IuserService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] private IJSRuntime JsRuntime { get; set; }


    [CascadingParameter] public Task<AuthenticationState> AuthState { get; set; }
    public IEnumerable<Claim> claims;
    public ClaimsPrincipal user;
    public UserDTO userDto = new();


    private string? errorLabel = String.Empty;

    public async Task CreateAccount()
    {

        if (userDto.password != null && userDto.confirmPassword != null)
        {
            if (userDto.password.Equals(userDto.confirmPassword))
            {
                await _registerService.createUser(userDto);
                alertMsg();
            }
            else
            {
                Alert("make sure the password matches");
            }
        }
        else if(userDto.password == null || userDto.confirmPassword == null)
        {
            Alert("Provide the password");
        }

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
        if (userDto.userName != null && userDto.firstName != null && userDto.lastName != null &&
            userDto.phone != null && userDto.email != null && userDto.address != null && userDto.password != null)
        {
            if (userDto.password.Equals(userDto.confirmPassword))
            {
              
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
         
        
    }

   
    public async Task Alert(string msg)
    {
        await JsRuntime.InvokeAsync<object>("Alert", msg);
    }
}