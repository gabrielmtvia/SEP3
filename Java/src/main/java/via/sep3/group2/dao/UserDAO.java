package via.sep3.group2.dao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import via.sep3.group2.models.OrderDTO;
import via.sep3.group2.models.OrdersDTO;
import via.sep3.group2.models.UserDTO;
import via.sep3.group2.repository.OrderRepository;
import via.sep3.group2.repository.UserRepository;

import java.util.List;

@Repository
public class UserDAO {
    private UserRepository userRepository;
    private UserDTO userDTO;
    @Autowired
    public UserDAO(UserRepository userRepository)
    {
        this.userRepository=userRepository;
    }
   /* public List<OrdersDTO> getAllOrders(UserDTO userDTO)
    {
        return userDTO.getOrders();
    }*/



}


