package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.shared.BookDTO;
import via.sep3.group2.shared.GenreDTO;

import java.util.List;
@Repository
public interface IBookDAO {
     void CreateBook(BookDTO bookDTO);
    List<BookDTO> getAllBooks();
     BookDTO getBookByIsbn(String isbn);
     List<BookDTO> getAllBooksByGenre(GenreDTO genre);
    List<BookDTO> getAllBooksByTitle(String title);
    List<BookDTO> getAllBooksByAuthor(String author);
    void deleteBookByIsbn(String isbn);
}
