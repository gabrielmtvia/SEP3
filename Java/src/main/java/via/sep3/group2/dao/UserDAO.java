package via.sep3.group2.dao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.OrderDTO;
//import via.sep3.group2.models.OrdersDTO;

//import via.sep3.group2.models.UserDTO;
import via.sep3.group2.models.UserDTO;
import via.sep3.group2.repository.OrderRepository;
import via.sep3.group2.repository.UserRepository;

import java.util.List;

@Repository
public class UserDAO {

   // @Autowired
    private UserRepository userRepository;
   // private UserDTO userDTO;
    @Autowired
    public UserDAO(UserRepository userRepository)
    {
        this.userRepository=userRepository;
    }
    public void createUser(UserDTO userDTO){
        userRepository.save(userDTO);
    }
    public String getRole(String username,String password){

        return  userRepository.findByUsernameAndPassword(username,password).getRole();
    }

    public void updateUsernameOfUser(String newUsername,String username){
        userRepository.setUsernameForUser(newUsername,username);
    }
    //public List


   /* public List<OrdersDTO> getAllOrders(UserDTO userDTO)
    {
        return userDTO.getOrders();
    }*/



}


