package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.OrderDTO;

import java.util.List;

@Repository
public interface IOrderDAO {
    void createOrder(OrderDTO ordersDTO);
    List<OrderDTO> getOrdersByUsername(String username);
    long getSerialOrderByUsernameAndStatus(String username,String status);
    void updateStatusOfOrder(long id,String status);
    List<OrderDTO> getAllOrders();
    List<OrderDTO> getAllOrdersByStatus(String status);
}
