namespace ModelClasses;
using System.ComponentModel.DataAnnotations;
public class UserDTO
{   [Required]
    [StringLength(20, ErrorMessage = "UserName too long (8 characters limit).")]
    public string userName { get; set; }
    [Required]
    [StringLength(20, ErrorMessage = "firstName too long (8 characters limit).")]
    public string firstName { get; set; }
    [Required]
    [StringLength(20, ErrorMessage = "lastName too long (8 characters limit).")]
    public string lastName { get; set; }
    [Required]
    [StringLength(25, ErrorMessage = "Please provide email).")]
    public string email { get; set; }
    [Required]
    [StringLength(25, ErrorMessage = "address too long (8 characters limit).")]
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

    public UserDTO(string userName, string firstName, string lastName,string address,string phone,string email)
    {
        this.userName = userName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.phone = phone;
        this.email = email;
        
    }

    public UserDTO(string userName)
    {
        this.userName = userName;
    }
    
    public UserDTO(string userName, string firstName, string lastName,string address,string phone,string email, string password)
    {
        this.userName = userName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.password = password;
    }
}