package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.OrderDTO;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface OrderRepository extends JpaRepository<OrderDTO, Long> {
    @Query("select o from OrderDTO o JOIN FETCH o.user where o.user.username = :username")
    List<OrderDTO> findOrdersDTOByUser(@Param("username")String username);



    @Query("select o.id from OrderDTO o where o.user.username = :username and o.status = :status")
    long findOrdersDTOByUserAndStatus(@Param("username")String username, @Param("status")String status);


   @Query("select o from OrderDTO o where o.id = :id")
   OrderDTO findOrdersDTOById(@Param("id")long id);

    @Transactional
   @Modifying(clearAutomatically = true)
   @Query("update OrderDTO  o set o.status = :status1 where o.id = :id1")
   void setOrderStatus( @Param("status1")String status ,@Param("id1")long id);


    @Query("select o from OrderDTO o JOIN FETCH o.user where o.status = :status ")
    List<OrderDTO> findOrdersDTOByStatus(@Param("status") String status);

    @Query("select o from OrderDTO o JOIN FETCH o.user")
    List<OrderDTO> findOrderDTOBy();

}
