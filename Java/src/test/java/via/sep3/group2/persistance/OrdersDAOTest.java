package via.sep3.group2.persistance;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.util.Assert;
import via.sep3.group2.repository.OrderRepository;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.OrderDTO;
import via.sep3.group2.shared.UserDTO;

import java.sql.Date;
import java.sql.Timestamp;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;

@DataJpaTest
class OrdersDAOTest {
    @Autowired
    private TestEntityManager entityManager;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private OrderRepository ordersRepository;
    @Test
    void createOrder() {
        UserDTO userDTO=new UserDTO("a","a","CUSTOMER");
        userRepository.save(userDTO);
        UserDTO userDTO1=new UserDTO("b");
        userRepository.save(userDTO);



        /*String str = "1990-03-31";
        Date date = Date.valueOf(str);*/
        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO);
        ordersRepository.save(ordersDTO);



        List<OrderDTO> orders=ordersRepository.findOrdersDTOByUser("a");
        Assert.isTrue(orders.contains(ordersDTO));
        List<OrderDTO> orders2=ordersRepository.findOrdersDTOByUser("b");
        assertThat(orders2.contains(ordersDTO)).isFalse();

        List<OrderDTO> orders1=ordersRepository.findAll();
        System.out.println("------------------++++++++*******");
        for (OrderDTO o:orders1
             ) {
            System.out.println(o.getId()+", "+o.getDate()+", "+o.getStatus()+", "+o.getUserDTO().getUsername()+", "+o.getUserDTO().getRole());
        }




    }

    @Test
    void getOrdersByUsername() {
        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO1=new UserDTO("b","v","ADMIN");
        userRepository.save(userDTO);
        userRepository.save(userDTO1);


        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO);
        OrderDTO ordersDTO1=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO);

        OrderDTO ordersDTO2=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
        ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);

        List<OrderDTO> orders=ordersRepository.findOrdersDTOByUser("a");

        assertThat(ordersRepository.findOrdersDTOByUser("a").size()==2);

        Assert.isTrue(ordersRepository.findOrdersDTOByUser("a").contains(ordersDTO));
        Assert.isTrue(ordersRepository.findOrdersDTOByUser("a").contains(ordersDTO1));

        System.out.println("-------------- The List of Orders by Username---------------"+"\n");
        for (OrderDTO o:orders
             ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDateTime().toString()+
                    ", "+o.getStatus()+","+o.getUserDTO().getFirstname()+", "+o.getUserDTO().getRole()+"\n");

        }

        System.out.println("-------------- *****************************---------------");

//////////////////////////////
        List<OrderDTO> orders1=ordersRepository.findAll();
        System.out.println("-------------- The List of Orders ---------------"+"\n");
        for (OrderDTO o:orders1
        ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDateTime().toString()+
                    ", "+o.getStatus()+","+o.getUserDTO().getFirstname()+", "+o.getUserDTO().getRole()+"\n");

        }

        System.out.println("-------------- *****************************---------------");

    }

    @Test
    void findOrdersDTOByUserAndStatus(){
        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO1=new UserDTO("b","v","CUSTOMER");
        userRepository.save(userDTO);
        userRepository.save(userDTO1);
        String str = "1990-03-31";
        Date date = Date.valueOf(str);

        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO);
       // OrdersDTO ordersDTO1=new OrdersDTO(date,"NOTCONFIRMED",userDTO);

        OrderDTO ordersDTO2=new OrderDTO(timestamp,"CONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
      //  ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);
        System.out.println("-------------- The OrderID of Orders by Username and Status---------------"+"\n");
       // System.out.println(ordersRepository.findOrdersDTOByUserAndStatus("b","CONFIRMED"));
        assertThat(ordersRepository.findOrdersDTOByUserAndStatus("b","CONFIRMED")==2);

        System.out.println("-------------- ********************************************---------------"+"\n");

    }

    @Test
    void updateStatusOfOrder(){


        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO1=new UserDTO("b","v","CUSTOMER");
        userRepository.save(userDTO);
        userRepository.save(userDTO1);


        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp,"CONFIRMED",userDTO);
        OrderDTO ordersDTO1=new OrderDTO(timestamp,"CONFIRMED",userDTO);

        OrderDTO ordersDTO2=new OrderDTO(timestamp,"CONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
        ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);

        ordersRepository.setOrderStatus("DISPATCHED",9);
        Assert.isTrue(ordersRepository.findOrdersDTOById(9).getStatus().equals("DISPATCHED"));

        List<OrderDTO> orders=ordersRepository.findAll();

        System.out.println("--------------++++++++ The List of all Orders++++++ --------------"+"\n");
        for (OrderDTO o:orders
        ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDateTime().toString()+
                    ", "+o.getStatus()+"\n");

        }

        System.out.println("-------------- *****************************---------------");


    }

    @Test
    void getAllOrdersByStatus(){

        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO1=new UserDTO("b","v","CUSTOMER");
        userRepository.save(userDTO);
        userRepository.save(userDTO1);
        String str = "1990-03-31";
        Date date = Date.valueOf(str);

        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO);
        OrderDTO ordersDTO1=new OrderDTO(timestamp,"NOTCONFIRMED",userDTO);

        OrderDTO ordersDTO2=new OrderDTO(timestamp,"CONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
        ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);
        Set<OrderDTO> orders1= new HashSet<>();
        orders1.add(ordersDTO2);
        Assert.isTrue((ordersRepository.findOrdersDTOByStatus("CONFIRMED")).size()==1);
        Assert.isTrue(ordersRepository.findOrdersDTOByStatus("CONFIRMED").containsAll(orders1));


        List<OrderDTO> orders=ordersRepository.findOrdersDTOByStatus("CONFIRMED");

        System.out.println("-------------- The List of Orders by Username---------------"+"\n");
        for (OrderDTO o:orders
        ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDateTime().toString()+
                    ", "+o.getStatus()+"\n");

        }

        System.out.println("-------------- *****************************---------------");

    }
}