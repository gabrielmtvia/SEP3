package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.CompositeKey;
import via.sep3.group2.shared.JoinDTO;
import via.sep3.group2.shared.OrderLineWithCompositeKeyDTO;

import java.util.List;

@Repository
public interface OrderLineWithCompositeKeyRepository extends JpaRepository<OrderLineWithCompositeKeyDTO, CompositeKey> {








  /*  @Query("select  o.qte,o.bookDTO.title from OrderLineWithCompositeKeyDTO o join BookDTO b on o.isbn=b.isbn where o.id= :id")
    List<JoinDTO> getAllTheBookOfAnOrder(@Param("id")long id);*/
//@Modifying(clearAutomatically = true)
  @Query("SELECT New via.sep3.group2.shared.JoinDTO(o.id,b.isbn,b.title,b.price,o.qte) " +
          "from OrderLineWithCompositeKeyDTO o, BookDTO b  where o.id = :id And o.isbn = b.isbn")
  List<JoinDTO> getAllTheBooksOfAnOrder(@Param("id")long id);


}
