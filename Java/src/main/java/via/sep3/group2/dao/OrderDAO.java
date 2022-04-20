package via.sep3.group2.dao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import via.sep3.group2.models.OrderDTO;
import via.sep3.group2.repository.OrderRepository;


import java.util.List;

@Repository
public class OrderDAO
{
    private OrderRepository repository;

    @Autowired
    public OrderDAO(OrderRepository repository)
    {
        this.repository = repository;
    }

    public List<OrderDTO> getAllOrders()
    {
        return repository.findAll();
    }

    public void createOrder(OrderDTO order)
    {

        order.setAmount(order.getAmount()*55);
        repository.save(order);
    }
}
