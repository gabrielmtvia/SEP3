package via.sep3.group2.dao;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.util.Assert;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.UserDTO;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;

@DataJpaTest
//@AutoConfigureTestDatabase
class UserDAOTest {
    @Autowired
    private TestEntityManager entityManager;
    @Autowired
    private UserRepository repository;
    @Test
    void createUser() {

    }

    @Test
    void getRole() {
        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO2=new UserDTO("khaled","b","Admin");
        repository.save(userDTO);
        repository.save(userDTO2);

       // entityManager.persist(userDTO);
        Assert.isTrue(repository.findByUsernameAndPassword("khaled","b").getRole().equals("Admin"));
        System.out.println("----------------------------------------");
        System.out.println(userDTO.getUsername()+", "+userDTO.getPassword()+", "+userDTO.getRole());
        System.out.println("----------------------------------------");

        UserDTO userDTO55=new UserDTO("b");

    }
}