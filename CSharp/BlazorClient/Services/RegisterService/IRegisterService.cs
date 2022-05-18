using ModelClasses;

namespace BlazorClient.Services.RegisterService;

public interface IRegisterService
{
   Task  createUser(UserDTO userDto);
}