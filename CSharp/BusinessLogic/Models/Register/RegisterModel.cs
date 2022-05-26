using BusinessLogicServer.Networking.Register;
using Microsoft.AspNetCore.Mvc;
using ModelClasses;

namespace BusinessLogicServer.Models.Register;

public class RegisterModel: IRegisterModel
{
    private IRegisterNetworking RegisterNetworking;
    
    
    
    public RegisterModel(IRegisterNetworking RegisterNetworking)
    {
        this.RegisterNetworking = RegisterNetworking;
    }
    //
    // public async Task CreateUser(UserDTO userDto)
    // {
    //     await networking.CreateUser(userDto);
    // }
    public async Task CreateUser(UserDTO userDto)
    {
        await RegisterNetworking.CreateUser(userDto );
    }

    public async Task<string> GetRole(string userName, string password)
    {
       return await RegisterNetworking.GetRole(userName, password);
    }

    public async Task<List<UserDTO>> GetUsersByRole(string role)
    {
       return await RegisterNetworking.GetUsersByRole(role);
    }

    public async Task DeleteUser(string username)
    {
        await RegisterNetworking.DeleteUser(username);
    }

    public async Task<string> UpdateUser(string oldUsername, UserDTO user)
    {
       return await RegisterNetworking.UpdateUser(oldUsername, user);
    }
}