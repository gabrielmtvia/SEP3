package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.shared.BookDTO;
import java.util.List;

@Repository
public class BookDAO
{
    private BookRepository repository;

    public BookDAO(BookRepository repository)
    {
        this.repository = repository;
    }

    public List<BookDTO> getAllBooks()
    {
        return repository.findAll();
    }

    public BookDTO getBookByIsbn(String isbn)
    {
        return repository.findByIsbn(isbn);
    }

    public void addBook(BookDTO book){
        repository.saveAndFlush(book);
    }
}
