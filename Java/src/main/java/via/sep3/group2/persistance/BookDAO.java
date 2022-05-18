package via.sep3.group2.persistance;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
//import via.sep3.group2.models.BookDTO;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.shared.BookDTO;

import java.util.List;

@Repository
public class BookDAO {
    private BookRepository bookRepository;

    @Autowired
    public BookDAO(BookRepository bookRepository){
        this.bookRepository=bookRepository;
    }

    public void CreateBook(BookDTO bookDTO){

        bookRepository.save(bookDTO);
    }

    public List<BookDTO> getAllBooks(){
        return bookRepository.findAll();
    }

}
