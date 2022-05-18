

using System.Net.Http.Headers;
using System.Text.Json;
using ModelClasses;

namespace BlazorClient.Services.UserService;

public class UserServiceIMP : IUserService
{
    
    private readonly HttpClient httpClient;


    public UserServiceIMP(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<User?> GetUserAsync(string username, string password)
    {
        
        
        ///// Here method to get the role then we create a user to send it to Authentication
        User user = new User(username, password);
        
        var json = JsonSerializer.Serialize(user);
        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        await httpClient.PostAsync("/User", byteContent);
        
     // User user= new User(username,password,role);
        
        User? find = users.Find(user => user.userName.Equals(username));
        return find;
    }

    private List<User> users = new()
    {
        new User("Troels", "Troels1234", "Admin"),
        new User("Maria", "oneTwo3FOUR", "Customer"),
        new User("Anne", "password", "Employee")        
    };
}