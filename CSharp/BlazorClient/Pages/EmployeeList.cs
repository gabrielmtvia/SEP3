using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Pages;

public class EmployeeList : ComponentBase
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    public IEnumerable<UserDTO> Employees { get; set; }
    
    [Inject]
    public IRegisterService IRegisterService{ get; set; }

    private string role = "Employee";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Employees = await IRegisterService.GetUsersByRole(role);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
           
        }
        
     
    }

   
    
    public void Delete()
    {
        
    }

}