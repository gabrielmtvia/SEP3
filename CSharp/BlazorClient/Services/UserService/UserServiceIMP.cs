 
using ModelClasses;

namespace BlazorClient.Services.UserService;

public class UserServiceIMP : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
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