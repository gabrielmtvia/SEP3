package via.sep3.group2.dao;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.util.Assert;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.UserDTO;

import java.util.ArrayList;
import java.util.List;

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
        List<UserDTO> users= new ArrayList<>();
        users.clear();
        users.add(userDTO);
        users.add(userDTO2);

        Assert.isTrue(repository.findAll().size()==2);
    //    Assert.isTrue(repository.findAll().contains(users));

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