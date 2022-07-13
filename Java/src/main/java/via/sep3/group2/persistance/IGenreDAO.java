package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.GenreDTO;

import java.util.List;
@Repository
public interface IGenreDAO {
    void createGenre(GenreDTO genreDTO);
    List<GenreDTO> getAllGenre();
}
