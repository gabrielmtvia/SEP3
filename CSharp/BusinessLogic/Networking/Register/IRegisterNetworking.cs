using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Networking.Register;

public interface IRegisterNetworking
{
    public Task CreateUser(UserDTO userDto);
    public Task <string> GetRole(string userName, string password);

    public Task<List<UserDTO>> GetUsersByRole(string role);

    public Task DeleteUser(string username);
}