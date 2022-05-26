using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ModelClasses;

namespace BlazorClient.Pages;

public class EditCustomer_razor : ComponentBase
{
    public UserDTO UserDtoToView;

    [Inject]
    public IRegisterService IRegisterService { get; set; }
    

    public UserDTO userDto = new();

    public Task<User?> userDto2;

    private string role = "Customer";
    
    // public ClaimsPrincipal User { get; }
   
    // [Parameter]
    // public string? PageuserName { get; set; }
    
    [Inject] public IUserService IuserService{ get; set; }

    public List<UserDTO> Employees { get; set; }

    
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    
    public UserDTO GetUserAsync(string username)
    {
        return Employees.Find(user => user.userName.Equals(username));

    }
 
    protected override async Task OnInitializedAsync()
    {

        try
        {

            Employees = await IRegisterService.GetUsersByRole(role);

           string username  = authenticationStateTask.Result.User.Identity.Name;
               
            UserDtoToView = GetUserAsync(username);


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;

        }


    }

    public void Update()
    {
      
        Console.WriteLine(UserDtoToView.userName);
        //  IRegisterService.update(userDto, userName);



    }
}