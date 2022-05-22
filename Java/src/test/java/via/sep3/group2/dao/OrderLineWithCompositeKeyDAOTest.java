package via.sep3.group2.dao;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
//import via.sep3.group2.models.*;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.repository.OrderLineRepository;
import via.sep3.group2.repository.OrderRepository;
import via.sep3.group2.repository.UserRepository;
import via.sep3.group2.shared.*;

import java.sql.Date;
import java.sql.Timestamp;
import java.util.List;

@DataJpaTest
class OrderLineWithCompositeKeyDAOTest {

    @Autowired
    BookRepository bookRepository;
    @Autowired
    OrderLineRepository orderLineRepository;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private OrderRepository ordersRepository;
     @Autowired
    private OrderLineRepository orderLineWithCompositeKeyRepository;

    @Test
    void createOrderLine() {
        UserDTO userDTO=new UserDTO("a","a","CUSTOMER");
        userRepository.save(userDTO);

        String str = "1990-03-31";
        Date date = Date.valueOf(str);

        Timestamp timestamp = new Timestamp(System.currentTimeMillis());
        OrderDTO ordersDTO=new OrderDTO(timestamp ,"NOTCONFIRMED",userDTO);
        ordersRepository.save(ordersDTO);


        BookDTO book1=new BookDTO("1","Java",12.5);
        bookRepository.save(book1);
        BookDTO book2=new BookDTO("2","C Sharp",20);
        bookRepository.save(book2);


       OrderLineDTO orderLineWithCompositeKeyDTO1=new OrderLineDTO(ordersDTO.getId(),"1",6);
        OrderLineDTO orderLineWithCompositeKeyDTO2=new OrderLineDTO(ordersDTO.getId(),"2",4);



        orderLineWithCompositeKeyRepository.save(orderLineWithCompositeKeyDTO1);
        orderLineWithCompositeKeyRepository.save(orderLineWithCompositeKeyDTO2);



       List<OrderLineDTO>  orderlines =(orderLineWithCompositeKeyRepository.findAll());
       // System.out.println(orderlines.get(0).getBookDTO());

        for (OrderLineDTO o:orderlines
             ) {
            System.out.println(o.getId()+", "+o.getIsbn()+", "+o.getQte()
                //   + o.getBookDTO().getTitle()
                    +
                    "\n");

        }

        List<JoinDTO> books=orderLineWithCompositeKeyRepository.getAllTheBooksOfAnOrder(ordersDTO.getId());

        for (JoinDTO b:books
             ) {
           //System.out.println(", "+b.+", "+b.getBookDTO().getTitle()+", "+b.getBookDTO().getPrice());
            System.out.println(b.getId()+", " +
                    b.getIsbn()+","+
                    b.getTitle()+", " +
                    b.getPrice()+", "+
                    b.getQte()+"\n"
                    );

        }
    }
}