
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
    public string errorLabel = String.Empty;
    public bool showModal;


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

    
    
    public async Task Delete(string username)
    {
        errorLabel = "";
        try
        { 
           
            await IRegisterService.DeleteUser(username);
            Employees = await IRegisterService.GetUsersByRole(role);
            NavigationManager.NavigateTo("/ListOfEmployee");
        } catch (Exception e)
        {
            errorLabel = e.Message;
        }
    }
    
    // public void Delete()
    // {
    //    
    //     
    //         // await IRegisterService.DeleteUser(username);
    //         showModal = true;
    //      
    //    
    // }
    //
    // public async Task Yees(string username)
    // {
    //    
    //     await IRegisterService.DeleteUser(username);
    //     NavigationManager.NavigateTo("/ListOfEmployee");
    //     showModal = false;
    // }
    //
    // public void Proceed()
    // {
    //     showModal = false;
    //    //NavigationManager.NavigateTo("/ListOfEmployee");
    // }

}