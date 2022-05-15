using System.Data.SqlTypes;

namespace ModelClasses;

public class OrderDTO
{
    public long SerialOrder { get; set; }
    public string Date { get; set; }
    public OrderStatus Status { get; set; }
    public string Username { get; set; }
}