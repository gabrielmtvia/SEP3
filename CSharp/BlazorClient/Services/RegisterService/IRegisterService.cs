using ModelClasses;

namespace BlazorClient.Services.RegisterService;

public interface IRegisterService
{
   Task  createUser(UserDTO userDto);
   Task<List<UserDTO>> GetUsersByRole(string role);
   Task<UserDTO?> GetO(string role);
}