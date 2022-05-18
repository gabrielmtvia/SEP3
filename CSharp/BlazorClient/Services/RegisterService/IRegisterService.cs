using ModelClasses;

namespace BlazorClient.Services.RegisterService;

public interface IRegisterService
{
    void  createUser(UserDTO userDto);
}