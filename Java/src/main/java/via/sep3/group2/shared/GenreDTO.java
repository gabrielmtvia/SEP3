package via.sep3.group2.shared;

import via.sep3.grpc.book.Book;
import via.sep3.grpc.order.Order;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

@Entity
@Table (name="genre")
public class GenreDTO {
    @Id
    private String name;
    private String url;

    @ManyToMany (mappedBy = "genres",cascade = CascadeType.ALL)
    Set<BookDTO> books;

    public GenreDTO()
    {
    }

    public GenreDTO(Book.GenreMessage message)
    {
        name = message.getName();
        url = message.getUrl();
    }

    public static List<GenreDTO> generateGenreListFromListGenreMessage(Book.ListGenreMessage message)
    {
        ArrayList<GenreDTO> genreDTOS = new ArrayList<>();
        for (Book.GenreMessage m : message.getGenresList())
        {
            genreDTOS.add(new GenreDTO(m));
        }

        return genreDTOS;
    }

    public Book.GenreMessage buildGenreMessage()
    {
        return Book.GenreMessage.newBuilder().setName(name).setUrl(url).build();
    }

    public static Book.ListGenreMessage genresToMessage(Iterable<GenreDTO> genres)
    {
        ArrayList<Book.GenreMessage> genrs= new ArrayList<>();
        for (GenreDTO gnr : genres)
        {
            genrs.add(gnr.buildGenreMessage());
        }
        Book.ListGenreMessage listGenreMessage = Book.ListGenreMessage.newBuilder().addAllGenres(genrs).build();
        return listGenreMessage;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getUrl()
    {
        return url;
    }

    public void setUrl(String url)
    {
        this.url = url;
    }

    public Set<BookDTO> getBooks()
    {
        return books;
    }

    public void setBooks(Set<BookDTO> books)
    {
        this.books = books;
    }
}