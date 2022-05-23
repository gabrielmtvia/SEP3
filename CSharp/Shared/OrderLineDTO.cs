namespace ModelClasses;

public class OrderLineDTO
{
    public long? SerialOrder { get; set; }
    public string Isbn { get; set; } 
    public int Quantity { get; set; }

    public OrderLineDTO(string isbn, int quantity)
    {
        Isbn = isbn;
        Quantity = quantity;
    }

    public OrderLineDTO(long? serialOrder, string isbn, int quantity)
    {
        SerialOrder = serialOrder;
        Isbn = isbn;
        Quantity = quantity;
    }

    public OrderLineDTO()
    {
    }
}