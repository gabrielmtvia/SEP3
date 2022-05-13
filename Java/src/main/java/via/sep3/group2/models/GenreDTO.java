package via.sep3.group2.models;

import javax.persistence.*;
import java.util.Set;

@Entity
@Table (name="genre")
public class GenreDTO {
    @Id
    private String type;
    @ManyToMany (mappedBy = "genres",cascade = CascadeType.ALL)
    Set<BookDTO> books;
}
