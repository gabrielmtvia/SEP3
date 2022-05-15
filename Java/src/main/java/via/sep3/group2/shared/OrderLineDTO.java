package via.sep3.group2.shared;

import javax.persistence.*;

@Entity
@Table(name="orderline")
public class OrderLineDTO {
    @EmbeddedId
    OrderLineKey id;

    @ManyToOne
    @MapsId("orderserial")
    @JoinColumn(name="serialorder"    )
    OrderDTO orderDTO;

    @ManyToOne
    @MapsId("bookisbn")
    @JoinColumn(name="isbn",
                foreignKey = @ForeignKey(
                        name="isbn",
                        foreignKeyDefinition = "FOREIGN KEY (isbn) REFERENCES book(isbn) ON UPDATE CASCADE ON DELETE CASCADE ")
    )
    BookDTO bookDTO;

    private int qte;

}
