using Microsoft.AspNetCore.Components;
using ModelClasses;


namespace BlazorClient.Pages;
 
public class LoginBase : ComponentBase
{

    // public string? userName { get; set; }
    // public string? password { get; set; }
    private string errorLabel = String.Empty;
    //
    // [Inject]
    // public NavigationManager NavigationManager { get; set; }

    public User user = new User();
    // private string? errorLabel;
    //
    protected async Task LoginAsync()
    {
        errorLabel = "";
        try
        {
            
            Console.WriteLine(user.name);
            Console.WriteLine(user.password);
         //   await authService.LoginAsync(userName, password);
        // NavigationManager.NavigateTo("/OrderList");
        }
        catch (Exception e)
        {
          errorLabel = $"Error: {e.Message}";
        }
    }


}