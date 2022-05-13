package via.sep3.group2.models;

import javax.persistence.*;

@Entity
@Table(name="orderline")
public class OrderLineDTO {
    @EmbeddedId
    OrderLineKey id;

    @ManyToOne
    @MapsId("orderserial")
    @JoinColumn(name="serialorder"    )
    OrdersDTO ordersDTO;

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
