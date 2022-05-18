using ModelClasses;

namespace BusinessLogicServer.Networking.Register;

public class RegisterNetworking: IRegisterNetworking
{
    private UserService.UserServiceClient userClient;

    public RegisterNetworking(UserService.UserServiceClient userClient)
    {
        this.userClient = userClient;
    }

    public async Task CreateUser(UserDTO userDto)
    {
        
        
      await  userClient.createUserAsync(new UserMessage
        {
            Username = userDto.userName, Password = userDto.password, Firstname = userDto.firstName, Lastname = userDto.lastName,
            Address = userDto.address, Phone = userDto.phone, Email = userDto.email, Role = userDto.role
        });
       
    }

    public async Task<string> GetRole(string username, string password)
    {
        throw new NotImplementedException();
    }
}