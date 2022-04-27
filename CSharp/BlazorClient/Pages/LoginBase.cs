using Microsoft.AspNetCore.Components;
using ModelClasses;


namespace BlazorClient.Pages;
 
public class LoginBase : ComponentBase
{

    public string? userName { get; set; }
    public string? password { get; set; }

    //
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    // public User User { get; set; }
    // private string? errorLabel;
    //
    private async Task LoginAsync()
    {
       // errorLabel = "";
        try
        {
         //   await authService.LoginAsync(userName, password);
         NavigationManager.NavigateTo("/OrderList");
        }
        catch (Exception e)
        {
         //   errorLabel = $"Error: {e.Message}";
        }
    }


}