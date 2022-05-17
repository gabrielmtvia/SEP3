package via.sep3.group2.dao;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.util.Assert;
import via.sep3.group2.repository.OrdersRepository;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.OrdersDTO;
import via.sep3.group2.shared.UserDTO;

import java.sql.Date;
import java.util.List;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;

@DataJpaTest
class OrdersDAOTest {
    @Autowired
    private TestEntityManager entityManager;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private OrdersRepository ordersRepository;
    @Test
    void createOrder() {
        UserDTO userDTO=new UserDTO("a","a","CUSTOMER");
        userRepository.save(userDTO);
        UserDTO userDTO1=new UserDTO("b");
        userRepository.save(userDTO);

        UserDTO userDTO2=new UserDTO("a");

        String str = "1990-03-31";
        Date date = Date.valueOf(str);
        OrdersDTO ordersDTO=new OrdersDTO(date,"NOTCONFIRMED",userDTO2);
        ordersRepository.save(ordersDTO);



        List<OrdersDTO> orders=ordersRepository.findOrdersDTOByUser("a");
        Assert.isTrue(orders.contains(ordersDTO));
        List<OrdersDTO> orders2=ordersRepository.findOrdersDTOByUser("b");
        assertThat(orders2.contains(ordersDTO)).isFalse();




    }

    @Test
    void getOrdersByUsername() {
        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO1=new UserDTO("b","v","ADMIN");
        userRepository.save(userDTO);
        userRepository.save(userDTO1);
        String str = "1990-03-31";
        Date date = Date.valueOf(str);
        OrdersDTO ordersDTO=new OrdersDTO(date,"NOTCONFIRMED",userDTO);
        OrdersDTO ordersDTO1=new OrdersDTO(date,"NOTCONFIRMED",userDTO);

        OrdersDTO ordersDTO2=new OrdersDTO(date,"NOTCONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
        ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);
        System.out.println("KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
      // ordersRepository.findOrdersDTOById(1).setStatus("ggggggg");
      // ordersRepository.setOrderStatus(1,"anything");

      //  ordersRepository.setOrderStatus("DELIEVRED",2);
     //   System.out.println("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
     //   System.out.println(ordersDTO.getStatus());

      //  System.out.println(ordersRepository.findOrdersDTOById(1).getStatus()+"******************");
       // List<OrdersDTO> orders=ordersRepository.findOrdersDTOByUser(userDTO.getUsername());
        List<OrdersDTO> orders=ordersRepository.findOrdersDTOByUser("a");

        assertThat(ordersRepository.findOrdersDTOByUser("a").size()==2);
        Assert.isTrue(ordersRepository.findOrdersDTOByUser("a").contains(ordersDTO));
        Assert.isTrue(ordersRepository.findOrdersDTOByUser("a").contains(ordersDTO1));

        System.out.println("-------------- The List of Orders by Username---------------"+"\n");
        for (OrdersDTO o:orders
             ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDate().toString()+
                    ", "+o.getStatus()+","+o.getUserDTO().getFirstname()+", "+o.getUserDTO().getRole()+"\n");

        }

        System.out.println("-------------- *****************************---------------");

//////////////////////////////
        List<OrdersDTO> orders1=ordersRepository.findAll();
        System.out.println("-------------- The List of Orders ---------------"+"\n");
        for (OrdersDTO o:orders1
        ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDate().toString()+
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
        OrdersDTO ordersDTO=new OrdersDTO(date,"NOTCONFIRMED",userDTO);
       // OrdersDTO ordersDTO1=new OrdersDTO(date,"NOTCONFIRMED",userDTO);

        OrdersDTO ordersDTO2=new OrdersDTO(date,"NOTCONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
      //  ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);
        System.out.println("-------------- The OrderID of Orders by Username and Status---------------"+"\n");
        System.out.println(ordersRepository.findOrdersDTOByUserAndStatus("b","NOTCONFIRMED"));
        System.out.println("-------------- ********************************************---------------"+"\n");

    }

    @Test
    void updateStatusOfOrder(){


        UserDTO userDTO=new UserDTO("a","b","CUSTOMER");
        UserDTO userDTO1=new UserDTO("b","v","CUSTOMER");
        userRepository.save(userDTO);
        userRepository.save(userDTO1);
        String str = "1990-03-31";
        Date date = Date.valueOf(str);
        OrdersDTO ordersDTO=new OrdersDTO(date,"NOTCONFIRMED",userDTO);
        OrdersDTO ordersDTO1=new OrdersDTO(date,"NOTCONFIRMED",userDTO);

        OrdersDTO ordersDTO2=new OrdersDTO(date,"NOTCONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
        ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);

        //ordersRepository.findOrdersDTOById(1).setStatus("ggggggg");
       // ordersRepository.setOrderStatus(1,"anything");
       // Assert.isTrue(ordersRepository.findOrdersDTOById(1).getStatus().equals("ggggggg"));

       // userDTO.setUsername("khaled");
        //userRepository.save(userDTO);
        //userRepository.flush();
        ordersRepository.setOrderStatus("DELIVERED",7);
        Assert.isTrue(ordersRepository.findOrdersDTOById(7).getStatus().equals("DELIVERED"));

        List<OrdersDTO> orders=ordersRepository.findOrdersDTOByUser("a");

        System.out.println("-------------- The List of Orders by Username---------------"+"\n");
        for (OrdersDTO o:orders
        ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDate().toString()+
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
        OrdersDTO ordersDTO=new OrdersDTO(date,"NOTCONFIRMED",userDTO);
        OrdersDTO ordersDTO1=new OrdersDTO(date,"NOTCONFIRMED",userDTO);

        OrdersDTO ordersDTO2=new OrdersDTO(date,"CONFIRMED",userDTO1);
        ordersRepository.save(ordersDTO);
        ordersRepository.save(ordersDTO1);
        ordersRepository.save(ordersDTO2);

        List<OrdersDTO> orders=ordersRepository.findOrdersDTOByStatus("CONFIRMED");

        System.out.println("-------------- The List of Orders by Username---------------"+"\n");
        for (OrdersDTO o:orders
        ) {
            System.out.println(o.getId()+", "+o.getUserDTO().getUsername()+", "+o.getDate().toLocalDate().toString()+
                    ", "+o.getStatus()+"\n");

        }

        System.out.println("-------------- *****************************---------------");

    }
}