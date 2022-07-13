package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.lang.Nullable;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.OrderDTO;
//import via.sep3.group2.models.OrdersDTO;

//import via.sep3.group2.models.UserDTO;
//import via.sep3.group2.models.UserDTO;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.UserDTO;

import java.util.List;

@Repository
public class UserDAO implements IUserDAO {

    //@Autowired
    private UserRepository userRepository;
   // private UserDTO userDTO;
    @Autowired
    public UserDAO(UserRepository userRepository)
    {
        this.userRepository=userRepository;
    }
    @Override
    public void createUser(UserDTO userDTO) {
        try {
            userRepository.save(userDTO);
        } catch (Exception e) {
        }
    }
    @Override
    @Nullable
    public String getRole(String username,String password)  {
             String role="NO_ROLE";
             //////
       try {
            role=userRepository.findByUsernameAndPassword(username,password).getRole();
            } catch (Exception e) {
       // e.printStackTrace();
    }
        /////

        return role;
    }
    @Override
    public void updateUsernameOfUser(String newUsername,String username){
        userRepository.setUsernameForUser(newUsername,username);
    }
    @Override
    public UserDTO findUserByUsername(String username){
        return userRepository.findByUsername(username);
    }
    @Override
    public List<UserDTO> getUsersByRole(String role){
        return userRepository.findByRole(role);
    }
    @Override
    public void deleteUser(String username){
        userRepository.deleteByUsername(username);
    }
    @Override
    public void updateUser(String username, UserDTO userDTO){
        userRepository.updateNewUser(username,userDTO);
    }
    @Override
    public boolean isUserExist(String username){
      return   userRepository.existsUserDTOByUsername(username);
    }


}


