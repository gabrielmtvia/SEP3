package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import via.sep3.group2.models.OrderDTO;

@Repository
public interface OrderRepository extends JpaRepository<OrderDTO, Long>
{
   // OrderDTO findByIdAndAmount(@Param("id")Long id, @Param("amount")double price);

}
