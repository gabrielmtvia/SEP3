package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.UserDTO;

@Repository
public interface UserRepository extends JpaRepository<UserDTO, String> {
//UserDTO.
}
