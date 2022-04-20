package via.sep3.group2.models;

import javax.persistence.*;

@Entity
@Table(name = "orders")
public class OrderDTO
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public long id;
    public String description;
    public double amount;
    public boolean delivered;

    public OrderDTO(long id, String description, double amount, boolean delivered)
    {
        this.id = id;
        this.description = description;
        this.amount = amount;
        this.delivered = delivered;
    }

    public OrderDTO()
    {
    }

    public void setId(long id)
    {
        this.id = id;
    }

    public long getId()
    {
        return id;
    }

    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    public double getAmount()
    {
        return amount;
    }

    public void setAmount(double amount)
    {
        this.amount = amount;
    }

    public boolean isDelivered()
    {
        return delivered;
    }

    public void setDelivered(boolean delivered)
    {
        this.delivered = delivered;
    }

}
