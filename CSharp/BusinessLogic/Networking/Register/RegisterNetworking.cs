using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ModelClasses;

namespace BusinessLogicServer.Networking.Register;

public class RegisterNetworking: IRegisterNetworking
{
    private UserService.UserServiceClient userClient;
    private CartService.CartServiceClient CartServiceClient;

    public RegisterNetworking(UserService.UserServiceClient userClient, CartService.CartServiceClient cartClient)
    {
        this.userClient = userClient;
        this.CartServiceClient = cartClient;
    }

    public async Task CreateUser(UserDTO userDto)
    {
        
        
      await  userClient.createUserAsync(new UserMessage
        {
            Username = userDto.userName, Password = userDto.password, Firstname = userDto.firstName, Lastname = userDto.lastName,
            Address = userDto.address, Phone = userDto.phone, Email = userDto.email, Role = userDto.role
        });
       
      
    }

    public async Task<string> GetRole(string userName, string password)
    {
    /*    
        //////////////////////////////////////////////
     //   OrderLineDTO orderLineDto1 = new OrderLineDTO("1", 12);
        OrderLineDTO orderLineDto2 = new OrderLineDTO("1", 3);
        OrderLineDTO orderLineDto3 = new OrderLineDTO("2", 4);
      //  List<OrderLineDTO> orderlines = new List<OrderLineDTO>();
        
       var orderlines = new List<OrderLineDTO>();
       // orderlines.Add(orderLineDto1);
        orderlines.Add(orderLineDto2);
        orderlines.Add(orderLineDto3);
      
        string username = "Khaled";
        CartLineDTO cartLineDto = new CartLineDTO();
        
        cartLineDto.username = username;
        cartLineDto.CartOrderLineDtos = orderlines;
        
        //////////////////////////////////////////////////////
       //var c = new CartOrderLine();
        CartOrderLine c1 = new CartOrderLine();
      //  c.Isbn=o
      
        var cs = new List<CartOrderLine>();


        foreach (OrderLineDTO col in cartLineDto.CartOrderLineDtos)
        {
            var c = new CartOrderLine();
            c.Isbn = col.Isbn;
            c.Qte = col.Quantity;
            cs.Add(c);

        }
        

        await CartServiceClient.confirmedCartAsync(new CartMessage
        {
            Username = cartLineDto.username,
            CartOrderLine =
               
            { 
            cs.ToArray()
        }

        });
*/
        
        /////////////////////////////////////////////////////////
        string  role = "";
     var answer=  await userClient.loginAsync(new LoginMessage{Password = password,Username = userName});
     role = answer.Role; 
     
     return role;
    }

    public async Task<List<UserDTO>> GetUsersByRole(string role)
    {
        var users = new List<UserDTO>();
        var allUsersAsync = await userClient.getUsersByRoleAsync(new TypeOfUsersMessage
        {
            Role = role
        });
        var ListOfUsers = allUsersAsync.UserMessage;
        foreach ( var UserMessageproto in ListOfUsers)
        {
           var user = new UserDTO
           {
               userName = UserMessageproto.Username, address = UserMessageproto.Address, email = UserMessageproto.Email,
               firstName = UserMessageproto.Firstname,
               lastName = UserMessageproto.Lastname, password = UserMessageproto.Password,
               phone = UserMessageproto.Phone, role = UserMessageproto.Role
           };
               users.Add(user);
            
        }

        return users;

    }

    public async Task DeleteUser(string username)
    {
        await userClient.deleteUserAsync(new UserNameMessage
        {
            Username = username
        });
    }
}