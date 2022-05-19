

using System.Net.Http.Headers;
using System.Text;
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

    // public async Task<string> GetUserAsync(string username, string password)
    // {
    //     User user = await GetUserAsync3(username, password);
    //     string? find = user.userName.Equals(username).ToString();
    //     return find;
    //
    // }

    public async Task<User?> GetUserAsync(string username, string password)
    {
        
        
        ///// Here method to get the role then we create a user to send it to Authentication
        User user = new User(username, password);
        //
        // var json = JsonSerializer.Serialize(user);
        // var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        // var byteContent = new ByteArrayContent(buffer);
        // byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        // await httpClient.PostAsync("/Register", byteContent);
        
        using HttpClient client = new();

        string todoAsJson = JsonSerializer.Serialize(user);

        StringContent content = new(todoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("/Register?userName&password", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
        User returned = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return returned;
        
     
    }
     // User user= new User(username,password,role);
          //   
          //   User? find = users.Find(user => user.userName.Equals(username));
          //   return find;
    private List<User> users = new()
    {
        new User("Troels", "Troels1234", "Admin"),
        new User("Maria", "oneTwo3FOUR", "Customer"),
        new User("Anne", "password", "Employee")        
    };
}