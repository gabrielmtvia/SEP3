/*namespace ModelClasses;

public class OrderDTO
{
    public long SerialOrder { get; set; }
    public string Date { get; set; }
    public OrderStatus Status { get; set; }
    public string Username { get; set; }
    
    public UserDTO UserDto { get; set; }

    public DateTime datetime;
    
    public string status1 { get; set; }

    public OrderDTO(long serialOrder, DateTime date1, string status, UserDTO userDto)
    {
        SerialOrder = serialOrder;
        datetime = date1;
        status1 = status;
        UserDto = userDto;
    }

    public OrderDTO(long serialOrder, string date, OrderStatus status, string username)
    {
        SerialOrder = serialOrder;
        Date = date;
        Status = status;
        Username = username;
    }

    public OrderDTO()
    {
    }

    public OrderDTO(long serialOrder, string status1)
    {
        SerialOrder = serialOrder;
        this.status1 = status1;
    }

    public OrderDTO(DateTime datetime, long serialOrder, string status1)
    {
        this.datetime = datetime;
        SerialOrder = serialOrder;
        this.status1 = status1;
    }
}
*/