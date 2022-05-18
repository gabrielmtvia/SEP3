 
using BusinessLogicServer.Networking.Register;
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
}