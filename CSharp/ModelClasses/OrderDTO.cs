using System.Data.SqlTypes;

namespace ModelClasses;

public class OrderDTO
{
    public long SerialOrder { get; set; }
    public DateTime Date { get; set; }
    public string Confirmed { get; set; }
    public string Username { get; set; }
}