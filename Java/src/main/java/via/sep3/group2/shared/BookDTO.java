package via.sep3.group2.shared;
import via.sep3.grpc.book.Book;

import javax.persistence.*;
import java.util.List;
import java.util.Set;

@Entity
@Table (name="book")
public class BookDTO {
    @Id
    private String isbn;
    private String title;
    private String author;
    private String edition;
    private String description;
    private double price;
    private String url;


    @OneToMany(
            mappedBy = "isbn",fetch = FetchType.LAZY)
    //  @MapsId("isbn")

    List<OrderLineDTO> orderlines;


    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(
            name = "book_genre",
            joinColumns = @JoinColumn(name = "isbn",

                    foreignKey = @ForeignKey(
                            name="isbn",
                            foreignKeyDefinition = "FOREIGN KEY (isbn) REFERENCES book(isbn) ON UPDATE CASCADE ON DELETE CASCADE "
                    )

            ),
            inverseJoinColumns = @JoinColumn(name = "type",
                    foreignKey = @ForeignKey(
                            name="type",
                            foreignKeyDefinition = "FOREIGN KEY (type) REFERENCES genre(type) ON UPDATE CASCADE ON DELETE CASCADE "

                    )
            )

    )
    Set<GenreDTO> genres;


    public BookDTO(String isbn, String title, String author, String edition, String description, double price, String url) {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.edition = edition;
        this.description = description;
        this.price = price;
        this.url = url;
    }

    public BookDTO(String isbn, String title, String author, String edition, String description, double price, String url, Set<GenreDTO> genres) {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.edition = edition;
        this.description = description;
        this.price = price;
        this.url = url;
        this.genres = genres;
    }

    public BookDTO(String isbn, String title, double price) {
        this.isbn = isbn;
        this.title = title;
        this.price = price;
    }

    public BookDTO(String isbn, String title, String author, String edition, String description, double price, String url, List<OrderLineDTO> orderlines, Set<GenreDTO> genres) {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.edition = edition;
        this.description = description;
        this.price = price;
        this.url = url;
        this.orderlines = orderlines;
        this.genres = genres;
    }


    public BookDTO() {

    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getEdition() {
        return edition;
    }

    public void setEdition(String edition) {
        this.edition = edition;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }



    public Set<GenreDTO> getGenres() {
        return genres;
    }

    public void setGenres(Set<GenreDTO> genres) {
        this.genres = genres;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public List<OrderLineDTO> getOrderlines() {
        return orderlines;
    }

    public void setOrderlines(List<OrderLineDTO> orderlines) {
        this.orderlines = orderlines;
    }
    /* @OneToMany(mappedBy = "bookDTO")
    Set<BookDTO> ratings;*/
    public Book.BookMessage buildBookMessage()
    {
        return Book.BookMessage.newBuilder().setIsbn(isbn).setTitle(title).setAuthor(author).setEdition(edition).setDescription(description)
                .setPrice(price).setUrl(url).build();
    }

}
