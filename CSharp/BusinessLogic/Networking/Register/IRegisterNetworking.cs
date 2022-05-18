using ModelClasses;

namespace BusinessLogicServer.Networking.Register;

public interface IRegisterNetworking
{
    public Task CreateUser(UserDTO userDto);
    public Task <string> GetRole(string username, string password);
}