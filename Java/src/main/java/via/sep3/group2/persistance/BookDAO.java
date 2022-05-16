package via.sep3.group2.persistance;

import org.springframework.stereotype.Repository;
import via.sep3.group2.repository.BookRepository;

@Repository
public class BookDAO
{
    private BookRepository repository;

    public BookDAO(BookRepository repository)
    {
        this.repository = repository;
    }

    public void addBook(String book){
        System.out.println(book);
    }
}
