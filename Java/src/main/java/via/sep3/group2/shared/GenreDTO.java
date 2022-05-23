package via.sep3.group2.shared;

import via.sep3.grpc.book.Book;
import via.sep3.grpc.genre.Genre;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;

@Entity
@Table (name="genre")
public class GenreDTO {
    @Id
    private String type;
    @ManyToMany (mappedBy = "genres",cascade = CascadeType.ALL)
    Set<BookDTO> books;

    public GenreDTO(String type, Set<BookDTO> books) {
        this.type = type;
        this.books = books;
    }

    public GenreDTO(String type) {
        this.type = type;
    }

    public GenreDTO() {

    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Set<BookDTO> getBooks() {
        return books;
    }

    public void setBooks(Set<BookDTO> books) {
        this.books = books;
    }

    public Genre.GenreMessage buildGenreMessage(){
        return Genre.GenreMessage.newBuilder().setType(type).build();
    }

    public static List<GenreDTO> generateGenreListFromListGenreMessage(Genre.ListGenreMessage message)
    {
        ArrayList<GenreDTO> genreDTOS = new ArrayList<>();
        for (Genre.GenreMessage m : message.getGenresList())
        {
            genreDTOS.add(new GenreDTO(m.getType()));
        }

        return genreDTOS;
    }

    public static Genre.ListGenreMessage genresToMessage(Iterable<GenreDTO> genres)
    {
        ArrayList<Genre.GenreMessage> genrs= new ArrayList<>();
        for (GenreDTO gnr : genres)
        {
            genrs.add(gnr.buildGenreMessage());
        }
        Genre.ListGenreMessage listGenreMessage = Genre.ListGenreMessage.newBuilder().addAllGenres(genrs).build();
        return listGenreMessage;
    }
}