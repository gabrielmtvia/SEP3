package via.sep3.group2.models;

import javax.persistence.*;
import java.util.Set;

@Entity
@Table (name="book")
public class BookDTO {
    @Id
    private String isbn;
    private String title;

    @ManyToMany
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

   /* @OneToMany(mappedBy = "bookDTO")
    Set<BookDTO> ratings;*/

}
