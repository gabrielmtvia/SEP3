using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ModelClasses;

namespace BlazorClient.Services.RegisterService;

public class RegisterServiceIMP : IRegisterService
{
    private readonly HttpClient _httpClient;

    public RegisterServiceIMP(HttpClient _httpClient)
    {
        this._httpClient = _httpClient;
    }
    
    public async Task createUser(UserDTO userDto)
    {
        // string Register = JsonSerializer.Serialize(userDto);
        //
        // StringContent content = new(Register, Encoding.UTF8, "application/json");
        //
        // HttpResponseMessage response = await _httpClient.PostAsync("/Register", content);
        // string responseContent = await response.Content.ReadAsStringAsync();
        //
        // if (!response.IsSuccessStatusCode)
        // {
        //     throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        // }
        
        // SubForum returned = JsonSerializer.Deserialize<SubForum>(responseContent, new JsonSerializerOptions
        // {
        //     PropertyNameCaseInsensitive = true
        // })!;
        //
        // return returned;
     /*   var json = JsonSerializer.Serialize(userDto);
        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        await _httpClient.PostAsync("/Register", byteContent);*/
        
        await _httpClient.PostAsJsonAsync("/Register", userDto);
    }

    public async Task<List<UserDTO>?> GetUsersByRole(string role)
    {
        https://localhost:7031/ListOfUsersByRole?role=Customer
     return  await _httpClient.GetFromJsonAsync<List<UserDTO>>($"https://localhost:7031/ListOfUsersByRole?role={role}");
     
 
       
    }

    public  Task update(UserDTO userDto, string userName)
    {
         Console.WriteLine(userDto.userName, "," + userName);
         return null;
    }

    public async Task DeleteUser(string username)
    {
        //https://localhost:7031/Register/sher


        HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:7031/Register/{username}");
        string content =   await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
    }
}