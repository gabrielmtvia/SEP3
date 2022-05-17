package via.sep3.group2.dao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.BookDTO;
//import via.sep3.group2.models.JoinDTO;
//import via.sep3.group2.models.OrderLineWithCompositeKeyDTO;
import via.sep3.group2.repository.OrderLineWithCompositeKeyRepository;
import via.sep3.group2.shared.JoinDTO;
import via.sep3.group2.shared.OrderLineWithCompositeKeyDTO;

import java.util.Iterator;
import java.util.List;

@Repository
public class OrderLineWithCompositeKeyDAO {
   private  OrderLineWithCompositeKeyRepository orderLineWithCompositeKeyRepository;
    @Autowired

    public OrderLineWithCompositeKeyDAO(OrderLineWithCompositeKeyRepository orderLineWithCompositeKeyRepository) {
        this.orderLineWithCompositeKeyRepository = orderLineWithCompositeKeyRepository;
    }

    public void createOrderLine(OrderLineWithCompositeKeyDTO orderLineWithCompositeKeyDTO){
        orderLineWithCompositeKeyRepository.save(orderLineWithCompositeKeyDTO);
    }
    public List<OrderLineWithCompositeKeyDTO> getAllOrderLines(){
        return  orderLineWithCompositeKeyRepository.findAll();
    }

    public List<JoinDTO> getAllTheBooksOfAnOrder(long id){
        return orderLineWithCompositeKeyRepository.getAllTheBooksOfAnOrder(id);
    }
}
