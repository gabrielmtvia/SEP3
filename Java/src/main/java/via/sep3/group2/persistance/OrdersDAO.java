package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.OrdersDTO;
//import via.sep3.group2.models.UserDTO;
import via.sep3.group2.repository.OrdersRepository;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.OrdersDTO;

import java.util.List;

@Repository
public class OrdersDAO {

    private OrdersRepository ordersRepository;

    @Autowired
    public OrdersDAO(OrdersRepository ordersRepository) {
        this.ordersRepository = ordersRepository;
    }

    public void createOrder(OrdersDTO ordersDTO){
        ordersRepository.save(ordersDTO);


    }
    public List<OrdersDTO> getOrdersByUsername(String username)
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
    public List<OrdersDTO> getAllOrders(){
        return ordersRepository.findAll();
    }

    public List<OrdersDTO> getAllOrdersByStatus(String status){
        return ordersRepository.findOrdersDTOByStatus(status);
    }


}
