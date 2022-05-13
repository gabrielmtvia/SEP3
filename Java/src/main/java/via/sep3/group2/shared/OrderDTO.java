package via.sep3.group2.shared;

import via.sep3.grpc.order.Order;

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

    public OrderDTO(Order.OrderMessage message)
    {
        this.id = message.getId();
        description = message.getDescription();
        amount = message.getAmount();
        delivered = message.getDelivered();
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

    // need it in the c# part as well , this is buliding your OrderMessage object(your order as a proto message)
    // if it is in this side of the system it means that this message will be sent as a response
    // when is in C# (in our case the client) it will be used when is sent a request
    public Order.OrderMessage buildOrderMessage()
    {
        return Order.OrderMessage.newBuilder().setId(id).setDescription(description).setAmount(amount).setDelivered(delivered).build();
    }
}
