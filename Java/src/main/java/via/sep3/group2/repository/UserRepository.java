package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.UserDTO;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface UserRepository extends JpaRepository<UserDTO, String> {

UserDTO findByUsernameAndPassword (@Param("username")String username, @Param("password")String password);

    @Transactional
    @Modifying(clearAutomatically = true)
    @Query("update UserDTO u set u.username = :newUsername where u.username = :Username")
    void setUsernameForUser( @Param("newUsername")String newUsername ,@Param("Username")String Username);
     UserDTO findByUsername(@Param("username")String username);

     List<UserDTO> findByRole(@Param("role")String role);
    @Transactional
     void deleteByUsername(@Param("username")String username);



}
