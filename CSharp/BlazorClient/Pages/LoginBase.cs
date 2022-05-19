using BlazorClient.authentication;
using BlazorClient.Services.UserService;
using Microsoft.AspNetCore.Components;


namespace BlazorClient.Pages;
 
public class LoginBase : ComponentBase
{

    
    
    [Inject] public IAuthService iAuthService { get; set; }
  
    [Inject] public NavigationManager NavigationManager { get; set; }

    public User user = new();
    private string? errorLabel = String.Empty;
    protected async Task LoginAsync()
    {
        errorLabel = "";
        try
        {
            Console.WriteLine(user.userName);
            Console.WriteLine(user.password);
            iAuthService.LoginAsync(user.userName, user.password);
            
            
       
          NavigationManager.NavigateTo("/PolicyExample1");
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
    
  

}