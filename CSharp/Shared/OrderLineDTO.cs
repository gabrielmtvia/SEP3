namespace ModelClasses;

public class OrderLineDTO
{
    public long? SerialOrder { get; set; }
    public string Isbn { get; set; } 
    public int Quantity { get; set; }

    public Book? book { get; set; } 

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

    public OrderLineDTO(Book book)
    {
        this.book = book;
    }

    public OrderLineDTO(Book book, long? serialOrder, string isbn, int quantity)
    {
        this.book = book;
        SerialOrder = serialOrder;
        Isbn = isbn;
        Quantity = quantity;
    }

    public OrderLineDTO()
    {
    }
}