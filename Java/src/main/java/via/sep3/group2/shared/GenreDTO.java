package via.sep3.group2.shared;

import via.sep3.grpc.genre.Genre;

import javax.persistence.*;
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
}