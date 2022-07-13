package via.sep3.group2.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import via.sep3.group2.shared.BookDTO;
import via.sep3.group2.shared.GenreDTO;

import java.util.List;

public interface GenreRepository extends JpaRepository<GenreDTO,String> {

}
