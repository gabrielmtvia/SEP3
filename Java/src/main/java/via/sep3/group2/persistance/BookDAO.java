package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.BookDTO;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.shared.BookDTO;
import via.sep3.group2.shared.GenreDTO;

import java.util.List;

@Repository
public class BookDAO {
    private BookRepository bookRepository;

    @Autowired
    public BookDAO(BookRepository bookRepository) {
        this.bookRepository = bookRepository;
    }

    public void CreateBook(BookDTO bookDTO) {

        bookRepository.save(bookDTO);
    }

    public List<BookDTO> getAllBooks() {
        return bookRepository.findAll();
    }

    public BookDTO getBookByIsbn(String isbn) {
        try {
            return bookRepository.findByIsbn(isbn);
        } catch (Exception e) {
           return  null; // e.printStackTrace();
        }
    }

    public List<BookDTO> getAllBooksByGenre(GenreDTO genre){
        return bookRepository.findAllByGenresIsContaining(genre);
    }
    public List<BookDTO> getAllBooksByTitle(String title){
        return bookRepository.findByTitle(title);
    }
    public List<BookDTO> getAllBooksByAuthor(String author){
        return bookRepository.findByAuthor(author);
    }


}
