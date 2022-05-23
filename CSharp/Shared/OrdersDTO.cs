namespace ModelClasses;

public class OrdersDTO
{
    public long id { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }
    public string username { get; set; }
    public UserDTO? user { get; set; } = null;

    public OrdersDTO(long id, DateTime date, string status, string username, UserDTO? user)
    {
        this.id = id;
        this.date = date;
        this.status = status;
        this.username = username;
        this.user = user;
    }

    public OrdersDTO(long id, string status, string username,DateTime date)
    {
        this.id = id;
        this.date = date;
        this.status = status;
        this.username = username;
    }

   

    public OrdersDTO()
    {
    }
    
    
    
}