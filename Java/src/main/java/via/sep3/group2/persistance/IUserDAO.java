package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.UserDTO;

import java.util.List;

@Repository
public interface IUserDAO {
    void createUser(UserDTO userDTO);
    String getRole(String username,String password);
    void updateUsernameOfUser(String newUsername,String username);
    UserDTO findUserByUsername(String username);
    List<UserDTO> getUsersByRole(String role);
    void deleteUser(String username);
    void updateUser(String username, UserDTO userDTO);
    boolean isUserExist(String username);
}
