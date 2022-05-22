using ModelClasses;

namespace BlazorClient.Services.EmployeeService;

public interface IEmployee
{
    public Task<IEnumerable<UserDTO>> GetEmployeeList(string role);
}