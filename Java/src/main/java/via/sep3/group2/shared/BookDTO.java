package via.sep3.group2.shared;

import via.sep3.grpc.book.Book;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;
import java.util.stream.Collectors;

@Entity
@Table(name = "book")
public class BookDTO
{
    @Id
    private String isbn;
    private String title;
    private String author;
    private String edition;
    private String description;
    private String imageUrl;
    private double price;




    @ManyToMany(fetch = FetchType.EAGER)
    @JoinTable(
            name = "book_genre",
            joinColumns = @JoinColumn(name = "isbn"),
            inverseJoinColumns = @JoinColumn(name = "id"))
    Set<GenreDTO> genres;
   /* @OneToMany(mappedBy = "bookDTO")
    Set<BookDTO> ratings;*/

    public BookDTO(String isbn, String title, String author, String edition, String description, String imageUrl, double price, Set<GenreDTO> genres)
    {
        this.isbn = isbn;
        this.title = title;
        this.author = author;
        this.edition = edition;
        this.description= description;
        this.imageUrl = imageUrl;
        this.price = price;
        this.genres = genres;
    }

    public BookDTO()
    {

    }

    public BookDTO(Book.BookMessage message)
    {
        isbn = message.getIsbn();
        title = message.getTitle();
        author = message.getAuthor();
        edition = message.getEdition();
        description = message.getDescription();
        imageUrl = message.getImageUrl();
        price = message.getPrice();
        genres = new HashSet<>(GenreDTO.generateGenreListFromListGenreMessage(message.getGenres()));
    }

    // create BookMessage from BookDTO object
   public Book.BookMessage buildBookMessage()
   {
       return Book.BookMessage
               .newBuilder()
               .setIsbn(isbn)
               .setTitle(title)
               .setAuthor(author)
               .setEdition(edition)
               .setDescription(description)
               .setImageUrl(imageUrl)
               .setPrice(price)
               .setGenres(GenreDTO.genresToMessage(genres))
               .build();
   }

    public String getIsbn()
    {
        return isbn;
    }

    public void setIsbn(String isbn)
    {
        this.isbn = isbn;
    }

    public String getTitle()
    {
        return title;
    }

    public void setTitle(String title)
    {
        this.title = title;
    }

    public String getAuthor()
    {
        return author;
    }

    public void setAuthor(String author)
    {
        this.author = author;
    }

    public String getEdition()
    {
        return edition;
    }

    public void setEdition(String edition)
    {
        this.edition = edition;
    }

    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    public String getImageUrl()
    {
        return imageUrl;
    }

    public void setImageUrl(String imageUrl)
    {
        this.imageUrl = imageUrl;
    }

    public double getPrice()
    {
        return price;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }

    public Set<GenreDTO> getGenres()
    {
        return genres;
    }

    public void setGenres(Set<GenreDTO> genres)
    {
        this.genres = genres;
    }
}