package via.sep3.group2.dao;

import com.google.common.collect.Lists;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import via.sep3.group2.models.*;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.repository.OrderLineWithCompositeKeyRepository;
import via.sep3.group2.repository.OrdersRepository;
import via.sep3.group2.repository.UserRepository;

import java.sql.Date;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@DataJpaTest
class OrderLineWithCompositeKeyDAOTest {

    @Autowired
    BookRepository bookRepository;
    @Autowired
    OrderLineWithCompositeKeyRepository orderLineRepository;
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private OrdersRepository ordersRepository;
     @Autowired
    private OrderLineWithCompositeKeyRepository orderLineWithCompositeKeyRepository;

    @Test
    void createOrderLine() {
        UserDTO userDTO=new UserDTO("a","a","CUSTOMER");
        userRepository.save(userDTO);

        String str = "1990-03-31";
        Date date = Date.valueOf(str);
        OrdersDTO ordersDTO=new OrdersDTO(date,"NOTCONFIRMED",userDTO);
        ordersRepository.save(ordersDTO);


        BookDTO book1=new BookDTO("1","Java",12.5);
        bookRepository.save(book1);
        BookDTO book2=new BookDTO("2","C Sharp",20);
        bookRepository.save(book2);


       OrderLineWithCompositeKeyDTO orderLineWithCompositeKeyDTO1=new OrderLineWithCompositeKeyDTO(ordersDTO.getId(),"1",6);
        OrderLineWithCompositeKeyDTO orderLineWithCompositeKeyDTO2=new OrderLineWithCompositeKeyDTO(ordersDTO.getId(),"2",4);



        orderLineWithCompositeKeyRepository.save(orderLineWithCompositeKeyDTO1);
        orderLineWithCompositeKeyRepository.save(orderLineWithCompositeKeyDTO2);


       List<OrderLineWithCompositeKeyDTO>  orderlines =(orderLineWithCompositeKeyRepository.findAll());
       // System.out.println(orderlines.get(0).getBookDTO());

        for (OrderLineWithCompositeKeyDTO o:orderlines
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