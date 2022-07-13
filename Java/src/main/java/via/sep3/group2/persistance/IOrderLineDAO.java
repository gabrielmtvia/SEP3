package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.OrderLineDTO;

import java.util.List;

@Repository
public interface IOrderLineDAO {
    void createOrderLine(OrderLineDTO orderLineWithCompositeKeyDTO);
    List<OrderLineDTO> getAllOrderLines();
    List<OrderLineDTO> getAllBooksByIdWithoutJoin(long id);
}
