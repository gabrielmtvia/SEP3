package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.OrderDTO;
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
        repository.save(order);
    }

    public void getAnOrderById(long id) {
        repository.findById(id);
    }
}