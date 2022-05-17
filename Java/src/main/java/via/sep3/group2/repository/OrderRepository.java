package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.OrderDTO;

@Repository
public interface OrderRepository extends JpaRepository<OrderDTO, Long>
{
   // OrderDTO findByIdAndAmount(@Param("id")Long id, @Param("amount")double price);

}
