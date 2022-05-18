namespace ModelClasses;
using System.ComponentModel.DataAnnotations;
public class UserDTO
{
    
    public string userName { get; set; }
    public string firstName { get; set; }
    
    public string lastName { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string role { get; set; }
    public string password { get; set; }
 
    
    
    
    public UserDTO(string userName, string firstName, string lastName, string email, string address, string phone, string role, string password)
    {
        this.userName = userName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.address = address;
        this.phone = phone;
        this.role = role;
        this.password = password;
       
    }

    public UserDTO(string userName, string firstName, string password)
    {
        this.userName = userName;
        this.firstName = firstName;
        this.password = password;
    }

    public UserDTO()
    {
        
    }
}