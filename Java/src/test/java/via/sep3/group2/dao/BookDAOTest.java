package via.sep3.group2.dao;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import via.sep3.group2.models.BookDTO;
import via.sep3.group2.repository.BookRepository;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
@DataJpaTest
class BookDAOTest {

    @Autowired
    BookRepository bookRepository;
    @Test
    void createBook() {

        BookDTO book1=new BookDTO("1","Java",12.5);
        bookRepository.save(book1);
        BookDTO book2=new BookDTO("2","C Sharp",20);
        bookRepository.save(book2);
        BookDTO book3=new BookDTO("3","Python",15);
        bookRepository.save(book3);
        List<BookDTO>  books=bookRepository.findAll();
        for (BookDTO b:books
             ) {
            System.out.println("**************************************");
            System.out.println(b.getIsbn());
            System.out.println("**************************************");
        }

    }
}