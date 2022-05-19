namespace ModelClasses;

public class OrdersDTO
{
    public long id { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }
    public string username { get; set; }

    public OrdersDTO(long id, DateTime date, string status, string username)
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