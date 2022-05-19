using ModelClasses;

namespace BusinessLogicServer.Models.Register;

public interface IRegisterModel
{
    public Task CreateUser(UserDTO userDto);
}