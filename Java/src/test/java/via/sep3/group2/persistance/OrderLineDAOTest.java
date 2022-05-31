package via.sep3.group2.persistance;

import org.springframework.util.Assert;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.repository.OrderLineRepository;
import via.sep3.group2.repository.OrderRepository;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.*;

import java.sql.Date;
import java.sql.Timestamp;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@DataJpaTest
class OrderLineDAOTest {
    @Autowired
    private TestEntityManager entityManager;
    @Autowired
    private BookRepository bookRepository;
    @Autowired
    private OrderLineRepository orderLineRepository;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private OrderRepository ordersRepository;


    @Test
    void createOrderLine() {
        UserDTO userDTO=new UserDTO("a","a","CUSTOMER");
        userRepository.save(userDTO);



        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp ,"NOTCONFIRMED",userDTO);
        ordersRepository.save(ordersDTO);


        BookDTO book1=new BookDTO("1","Java",12.5);
        bookRepository.save(book1);
        BookDTO book2=new BookDTO("2","C Sharp",20);
        bookRepository.save(book2);

       OrderLineDTO orderLineWithCompositeKeyDTO1=new OrderLineDTO(ordersDTO.getId(),"1",6);
        OrderLineDTO orderLineWithCompositeKeyDTO2=new OrderLineDTO(ordersDTO.getId(),"2",4);

        orderLineRepository.save(orderLineWithCompositeKeyDTO1);
        orderLineRepository.save(orderLineWithCompositeKeyDTO2);

        Set<OrderLineDTO> orderlines1= new HashSet<>();
        orderlines1.add(orderLineWithCompositeKeyDTO1);
        orderlines1.add(orderLineWithCompositeKeyDTO2);

        Assert.isTrue(orderLineRepository.findAll().containsAll(orderlines1));



       List<OrderLineDTO>  orderlines =(orderLineRepository.findAll());
       // System.out.println(orderlines.get(0).getBookDTO());

        for (OrderLineDTO o:orderlines
             ) {
            System.out.println(o.getId()+", "+o.getIsbn()+", "+o.getQte()
                //   + o.getBookDTO().getTitle()
                    +
                    "\n");

        }

       /* List<JoinDTO> books=orderLineRepository.getAllTheBooksOfAnOrder(ordersDTO.getId());

        for (JoinDTO b:books
             ) {
           //System.out.println(", "+b.+", "+b.getBookDTO().getTitle()+", "+b.getBookDTO().getPrice());
            System.out.println(b.getId()+", " +
                    b.getIsbn()+","+
                    b.getTitle()+", " +
                    b.getPrice()+", "+
                    b.getQte()+"\n"
                    );

        }*/
    }
}