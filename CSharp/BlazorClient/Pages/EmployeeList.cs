using Microsoft.AspNetCore.Components;
using ModelClasses;

namespace BlazorClient.Pages;

public class EmployeeList : ComponentBase
{
    public IEnumerable<UserDTO> Employees { get; set; }

    private string role = "Employee";

    protected override Task OnInitializedAsync()
    {
        try
        {
            LoadEmployees();
            return base.OnInitializedAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    private void LoadEmployees()
    {
        UserDTO e1 = new UserDTO()
        {
            userName = "Rojhat",
            firstName = "rojhat12",
            lastName = "efrini",
            address = "efrin",
            email = "efrin@outlook.com",
            phone = "7114121",
            password = "11111",


        };
        UserDTO e2 = new UserDTO()
        {
            userName = "Adam",
            firstName = "rojhat12",
            lastName = "kristen",
            address = "efrin",
            email = "efrin@outlook.com",
            phone = "7114121",
            password = "11111",


        };
        UserDTO e3 = new UserDTO()
        {
            userName = "Alex",
            firstName = "rojhat12",
            lastName = "muller",
            address = "efrin",
            email = "efrin@outlook.com",
            phone = "7114121",
            password = "11111",


        };
        Employees = new List<UserDTO>{e1, e2, e3};
    }
}