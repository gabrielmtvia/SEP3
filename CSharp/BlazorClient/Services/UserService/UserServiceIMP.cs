

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
    
    public async Task<string?> GetUserAsync2(string username, string password)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7031/Register?userName={username}&password={password}");
       
        string responseContent = await response.Content.ReadAsStringAsync();
        role2 = responseContent;

        return role2;

    }
    public string role2 = "";
    // public string role = "";

    // public async Task<User?> GetUserAsync(string username, string password)
    // {
    //     
    //     
    //     ///// Here method to get the role then we create a user to send it to Authentication
    //    // User user = new User(username, password);
    //     //
    //     // var json = JsonSerializer.Serialize(user);
    //     // var buffer = System.Text.Encoding.UTF8.GetBytes(json);
    //     // var byteContent = new ByteArrayContent(buffer);
    //     // byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //     // await httpClient.PostAsync("/Register", byteContent);
    //     
    //   
    //
    //    // string todoAsJson = JsonSerializer.Serialize(user);
    //
    //     //StringContent content = new(todoAsJson, Encoding.UTF8, "application/json");
    //     // $"https://localhost:7012/Forum/{id}
    //     //return await httpClient.GetFromJsonAsync<User>($"https://localhost:7031/Register?userName={username}&password={password}");
    //       using HttpClient client = new();
    //     HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7031/Register?userName={username}&password={password}");
    //    
    //     string responseContent = await response.Content.ReadAsStringAsync();
    //     GetUserAsync2(  username,   password);
    //      
    //     // if (!response.IsSuccessStatusCode)
    //     // {
    //     //     throw new Exception($"Error: {response.StatusCode}, {responseContent}");
    //     // }
    //     //
    //     // GetUserAsync2(username, password);
    //     // User todos = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions
    //     // {
    //     //     PropertyNameCaseInsensitive = true
    //     // })!;
    //     return new User(role2);
    //       string? user = JsonSerializer.Deserialize<string>(responseContent)!.ToString();
    //       User u = new User(username, password, user);
    //
    //       var s = user;
    //         return u;
    //     // User returned = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions
    //     // {
    //     //     PropertyNameCaseInsensitive = true
    //     // })!;
    //
    //
    //   //   User u = new User(username, password, responseContent.ToString());
    //   //   
    //   // //  Console.WriteLine(u.password+","+u.userName+", "+u.role);
    //   //   
    //   //   Console.WriteLine(responseContent);
    //    // return returned;
    //     
    //     
    //
    // }

    

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