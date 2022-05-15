using System.ComponentModel.DataAnnotations;
public class User
{
    
 
 
    //[Required]
    [StringLength(8, ErrorMessage = "UserName too long (8 characters limit).")]
    public string userName { get; set; }
    
    [Required, MinLength(5), MaxLength(13) ]
     public string password { get; set; }
     // public string name { get; set; }
     public string role { get; set; }
     // public string address { get; set; }
     // public string phone { get; set; }
     // public string email { get; set; }
     // public int salary { get; set; }
     //
    public User(string userName, string password, string role)
    {
        this.userName = userName;
        this.password = password;
        // this.name = name;
        this.role = role;
        // this.address = address;
        // this.phone = phone;
        // this.email = email;
        // this.salary = salary;
    }
    public User()
    {
    }
}