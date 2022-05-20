namespace ModelClasses;
using System.ComponentModel.DataAnnotations;
public class UserDTO
{
    [StringLength(8, ErrorMessage = "UserName too long (8 characters limit).")]
    public string userName { get; set; }
    [StringLength(8, ErrorMessage = "firstName too long (8 characters limit).")]
    public string firstName { get; set; }
    [StringLength(8, ErrorMessage = "lastName too long (8 characters limit).")]
    public string lastName { get; set; }
    [StringLength(13, ErrorMessage = "Please provide email).")]
    public string email { get; set; }
    [StringLength(13, ErrorMessage = "address too long (8 characters limit).")]
    public string address { get; set; }
    [Required]
    public string phone { get; set; }
  
    public string role { get; set; }
    [Required, MinLength(5), MaxLength(13) ]
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