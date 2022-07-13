package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
//import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.BookDTO;
import via.sep3.group2.shared.GenreDTO;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface BookRepository extends JpaRepository<BookDTO, String> {
    BookDTO findByIsbn(@Param("isbn")String isbn);

   List<BookDTO> findAllByGenresIsContaining(@Param("genre") GenreDTO genre);
   @Query("select b from BookDTO b where lower(b.title) LIKE lower(CONCAT('%',:title,'%'))")
   List<BookDTO> findByTitle(@Param("title")String title);
    @Query("select b from BookDTO b where lower(b.author) LIKE lower(CONCAT('%',:author,'%'))")
    List<BookDTO> findByAuthor(@Param("author")String author);

    @Transactional
    void deleteByIsbn(@Param("isbn")String isbn);
}
