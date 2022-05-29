package via.sep3.group2.persistance;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.util.Assert;
import via.sep3.group2.repository.BookRepository;
import via.sep3.group2.shared.BookDTO;

import java.util.ArrayList;
import java.util.List;

@DataJpaTest
class BookDAOTest {

    @Autowired
    BookRepository bookRepository;
    @Test
    void createBook() {

        BookDTO book1=new BookDTO("1","Java","khaled","5","java",12.5,"http://java.com");
        bookRepository.saveAndFlush(book1);
        BookDTO book2=new BookDTO("2","C Sharp","Elias","2","c sharp",20,"http://Csharp.com");
        bookRepository.saveAndFlush(book2);
        BookDTO book3=new BookDTO("3","Python","khaled","3","python",30.25,"http://python.com");
        bookRepository.saveAndFlush(book3);

        List<BookDTO>  books=new ArrayList<>();
       books.clear();
        books.add(book1);
        books.add(book2);
        books.add(book3);


        Assert.isTrue(bookRepository.findAll().size()==3);
        Assert.isTrue(bookRepository.findAll().containsAll(books));

    }

    @Test
    void getBookByIsbn(){
        BookDTO book=new BookDTO("4","Javascript","khaled","3","python",30.25,"http://python.com");
        bookRepository.saveAndFlush(book);
        Assert.isTrue(bookRepository.findByIsbn("4").equals(book));

    }
}