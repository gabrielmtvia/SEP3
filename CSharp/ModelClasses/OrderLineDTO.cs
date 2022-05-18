namespace ModelClasses;

public class OrderLineDTO
{
    public long? SerialOrder { get; set; }
    public long Isbn { get; set; }
    public int? Quantity { get; set; }
}