namespace ModelClasses;

public class Register
{
    

    public string name { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public String type { get; set; }
    public String createPassword { get; set; }
    public String confirmPassword { get; set; }
    
    
    
    public Register(string name, string firstName, string lastName, string email, string address, string phone, string type, string createPassword, string confirmPassword)
    {
        this.name = name;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.address = address;
        this.phone = phone;
        this.type = type;
        this.createPassword = createPassword;
        this.confirmPassword = confirmPassword;
    }
}