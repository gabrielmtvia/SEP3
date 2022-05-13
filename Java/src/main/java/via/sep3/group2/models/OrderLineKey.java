package via.sep3.group2.models;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;

@Embeddable
public class OrderLineKey  implements Serializable {

    @Column(name="order_serial")
    long orderserial;
    @Column(name="book_isbn")
    String bookisbn;
}
