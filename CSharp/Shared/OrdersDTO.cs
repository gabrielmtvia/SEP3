namespace ModelClasses;

public class OrdersDTO
{
    private long id { get; set; }
    private DateTime date { get; set; }
    private string status { get; set; }
    private string username { get; set; }

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