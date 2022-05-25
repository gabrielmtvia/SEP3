package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.OrdersDTO;
//import via.sep3.group2.models.UserDTO;
import via.sep3.group2.repository.OrderRepository;
import via.sep3.group2.shared.OrderDTO;

import java.util.List;

@Repository
public class OrderDAO {

    private OrderRepository ordersRepository;

    @Autowired
    public OrderDAO(OrderRepository ordersRepository) {
        this.ordersRepository = ordersRepository;
    }

    public void createOrder(OrderDTO ordersDTO){
        ordersRepository.saveAndFlush(ordersDTO);


    }
    public List<OrderDTO> getOrdersByUsername(String username)
    {
              return ordersRepository.findOrdersDTOByUser(username);
    }
    public long getSerialOrderByUsernameAndStatus(String username,String status){
        return ordersRepository.findOrdersDTOByUserAndStatus(username, status);
    }

    public void updateStatusOfOrder(long id,String status){

     ordersRepository.setOrderStatus(status,id);
   //  ordersRepository.flush();

     //ordersRepository.save()
    }
    public List<OrderDTO> getAllOrders(){
        return ordersRepository.findOrderDTOBy();
    }

    public List<OrderDTO> getAllOrdersByStatus(String status){
        return ordersRepository.findOrdersDTOByStatus(status);
    }


}
