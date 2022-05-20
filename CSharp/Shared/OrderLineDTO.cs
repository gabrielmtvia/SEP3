namespace ModelClasses;

public class OrderLineDTO
{
    public long? SerialOrder { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int? Quantity { get; set; }

    public Book Book { get; set; } = null!;
}