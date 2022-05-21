namespace ModelClasses;

public class OrderLineDTO
{
    public long? SerialOrder { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public int? Quantity { get; set; }

    public OrderLineDTO(long? serialOrder, int? quantity, string isbn)
    {
        SerialOrder = serialOrder;
        Quantity = quantity;
        Isbn = isbn;
    }

    public OrderLineDTO()
    {
    }
}