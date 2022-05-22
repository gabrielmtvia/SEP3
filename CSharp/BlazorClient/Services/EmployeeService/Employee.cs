using ModelClasses;

namespace BlazorClient.Services.EmployeeService;

public class Employee : IEmployee
{
    private readonly HttpClient httpClient;

    public Employee(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<IEnumerable<UserDTO>> GetEmployeeList(string role)
    {
        //
        // HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7031/Register?userName={username}&password={password}");
        //
        // string responseContent = await response.Content.ReadAsStringAsync();
        // role = responseContent;
        //
        // return role;
        
        return await httpClient.GetFromJsonAsync<ICollection<UserDTO>>( "");
        throw new NotImplementedException();
    }
}