package via.sep3.group2.persistance;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.util.Assert;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.UserDTO;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

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

        UserDTO userDTO=new UserDTO("a","a","a","a","a","123456789","a@.yahoo.com","Customer");
        UserDTO userDTO2=new UserDTO("b","b","b","b","b","02587269","b@.yahoo.com","Admin");
        repository.saveAndFlush(userDTO);
        repository.saveAndFlush(userDTO2);

        Set<UserDTO> users= new HashSet<>();
        users.add(userDTO);
        users.add(userDTO2);

        Assert.isTrue(repository.findAll().size()==2);
        Assert.isTrue(repository.findAll().containsAll(users));

    }

    @Test
    void getRole() {

        UserDTO userDTO=new UserDTO("Elias","123456","Customer");
        UserDTO userDTO2=new UserDTO("Admin","789456","Admin");
        repository.save(userDTO);
        repository.save(userDTO2);

        Assert.isTrue(repository.findByUsernameAndPassword("Elias","123456").getRole().equals("Customer"));
        Assert.isTrue(repository.findByUsernameAndPassword("Admin","789456").getRole().equals("Admin"));

    }
}