using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using ModelClasses;

namespace BlazorClient.Pages;

public class EditCustomer_razor : ComponentBase
{
    public UserDTO UserDtoToView;

    [Inject] public IRegisterService IRegisterService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IAuthService iAuthService { get; set; }
    [Inject] private IJSRuntime JsRuntime { get; set; }

    public UserDTO userDto = new();

    public Task<User?> userDto2;

    private string role = "Customer";

    public List<UserDTO> Customers { get; set; }


    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; }

    public UserDTO GetUserAsync(string username)
    {
        return Customers.Find(user => user.userName.Equals(username));
    }

    public string oldUsername;

    protected override async Task OnInitializedAsync()
    {
        // if (authenticationStateTask.Result.User.Identity.Name != null)
        // {
        //     oldUsername = authenticationStateTask.Result.User.Identity.Name;
        // }

        oldUsername = authenticationStateTask?.Result?.User?.Identity?.Name;
        try
        {
            Customers = await IRegisterService.GetUsersByRole(role);


            UserDtoToView = GetUserAsync(oldUsername);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string response;

    public async Task Update()
    {
        response = await IRegisterService.update(oldUsername, UserDtoToView);
        alertMsg();
    }


    public void alertMsg()
    {
        if (response.Equals("User with username:" + oldUsername + " is Updated"))
        {
            Alert("your data is updated");
        }
        else if (response.Equals("User with username: " + oldUsername + " is Updated to the new Username: " +
                                 UserDtoToView.userName + " Remember to Log in again to use the system"))
        {
            Alert(response);
            iAuthService.LogoutAsync();
        }
        else
        {
            Alert(response);
        }
    }

    private async Task Alert(string msg)
    {
        await JsRuntime.InvokeAsync<object>("Alert", msg);
    }
}