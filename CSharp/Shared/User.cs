using System.ComponentModel.DataAnnotations;
public class User
{
    
 
 
    //[Required]
    [StringLength(8, ErrorMessage = "UserName too long (8 characters limit).")]
    public string userName { get; set; }
    
    [Required, MinLength(5), MaxLength(13) ]
     public string password { get; set; }
     public string role { get; set; }
     
    
    public User(string userName, string password, string role)
    {
        this.userName = userName;
        this.password = password;
        this.role = role;
        
    }
    public User(string userName, string password)
    {
        this.userName = userName;
        this.password = password;

        
    }
   
    public User()
    {
    }
}