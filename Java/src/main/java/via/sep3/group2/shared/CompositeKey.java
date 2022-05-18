package via.sep3.group2.shared;

import java.io.Serializable;
import java.util.Objects;

public class CompositeKey implements Serializable {
    private Long id;
    private String isbn;

    public CompositeKey(){

    }

    public CompositeKey(Long serialOrder, String isbnBook) {
        this.id = serialOrder;
        this.isbn = isbnBook;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof CompositeKey)) return false;
        CompositeKey that = (CompositeKey) o;
        return id.equals(that.id) && isbn.equals(that.isbn);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, isbn);
    }
}
