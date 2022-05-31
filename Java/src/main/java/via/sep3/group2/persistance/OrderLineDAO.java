package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.BookDTO;
//import via.sep3.group2.models.JoinDTO;
//import via.sep3.group2.models.OrderLineWithCompositeKeyDTO;
import via.sep3.group2.repository.OrderLineRepository;
import via.sep3.group2.shared.BookDTO;
//import via.sep3.group2.shared.JoinDTO;
import via.sep3.group2.shared.OrderLineDTO;

import java.util.List;

@Repository
public class OrderLineDAO {
   private OrderLineRepository orderLineWithCompositeKeyRepository;
    @Autowired

    public OrderLineDAO(OrderLineRepository orderLineWithCompositeKeyRepository) {
        this.orderLineWithCompositeKeyRepository = orderLineWithCompositeKeyRepository;
    }

    public void createOrderLine(OrderLineDTO orderLineWithCompositeKeyDTO){
        orderLineWithCompositeKeyRepository.saveAndFlush(orderLineWithCompositeKeyDTO);
    }
    public List<OrderLineDTO> getAllOrderLines(){
        return  orderLineWithCompositeKeyRepository.findAll();
    }

    /*public List<JoinDTO> getAllTheBooksOfAnOrder(long id){
        return orderLineWithCompositeKeyRepository.getAllTheBooksOfAnOrder(id);
    }*/
    public List<OrderLineDTO> getAllBooksByIdWithoutJoin(long id){
        return orderLineWithCompositeKeyRepository.getAllById(id);
    }
}
