namespace ModelClasses;

public class Order
{
    public long id { get; set; }
    public string description { get; set; }
    public double amount { get; set; }
    public bool delivered { get; set; }

    public Order(long id, string description, double amount, bool delivered)
    {
        this.id = id;
        this.description = description;
        this.amount = amount;
        this.delivered = delivered;
    }

    public Order()
    {
    }
    
    
}