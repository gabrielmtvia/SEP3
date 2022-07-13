package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.BookDTO;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.shared.BookDTO;
import via.sep3.group2.shared.GenreDTO;

import java.util.List;

@Repository
public class BookDAO implements IBookDAO {
    private BookRepository bookRepository;

    @Autowired
    public BookDAO(BookRepository bookRepository) {
        this.bookRepository = bookRepository;
    }
    @Override
    public void CreateBook(BookDTO bookDTO) {
        if ( !bookRepository.existsById(bookDTO.getIsbn()))
            bookRepository.save(bookDTO);

    }
    @Override
    public List<BookDTO> getAllBooks() {
        return bookRepository.findAll();
    }
    @Override
    public BookDTO getBookByIsbn(String isbn) {
        try {

            return bookRepository.findByIsbn(isbn);
        } catch (Exception e) {
           return  null; // e.printStackTrace();
        }
    }
    @Override
    public List<BookDTO> getAllBooksByGenre(GenreDTO genre){
        return bookRepository.findAllByGenresIsContaining(genre);
    }
    @Override
    public List<BookDTO> getAllBooksByTitle(String title){
        return bookRepository.findByTitle(title);
    }
    @Override
    public List<BookDTO> getAllBooksByAuthor(String author){
        return bookRepository.findByAuthor(author);
    }
    @Override
    public void deleteBookByIsbn(String isbn){
        try{
            bookRepository.deleteByIsbn(isbn);
        } catch (Exception e){

        }

    }


}
