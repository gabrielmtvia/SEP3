using BlazorClient.authentication;
using BlazorClient.Services.UserService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ModelClasses;


namespace BlazorClient.Pages;
 
public class LoginBase : ComponentBase
{

    
    [Inject] private IJSRuntime JsRuntime { get; set; }
    [Inject] public IAuthService iAuthService { get; set; }
    [Inject] public IUserService IuserService{ get; set; }
  
    [Inject] public NavigationManager NavigationManager { get; set; }

    public User user = new();
    private string? errorLabel = String.Empty;
    protected async Task LoginAsync()
    {
        errorLabel = "";
        try
        {
          
            iAuthService.LoginAsync(user.userName, user.password);
            
          NavigationManager.NavigateTo("/PolicyExample1");
          
         Thread.Sleep(500);
         alertMsg();
        }
        catch (Exception e)
        {
          errorLabel = $"Error: {e.Message}";
        }
    }
    
    protected void  MovePageToRegister()
    {
        NavigationManager.NavigateTo("/Register");
    }
    
    public async void alertMsg()
    {
        string s = await IuserService.GetUserAsync(user.userName, user.password);
        if (s.Equals("Admin"))
        {
            Alert("Welcome back " + user.userName );
        }
        if (s.Equals("Customer"))
        {
            Alert("Welcome back " + user.userName);
        }
        if (s.Equals("Employee"))
        {
            Alert("Welcome back " + user.userName);
        }
        
    }

    private async Task Alert(string msg)
    {
        await JsRuntime.InvokeAsync<object>("Alert", msg);
    }

}