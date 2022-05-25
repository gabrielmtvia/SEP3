package via.sep3.group2.shared;
import via.sep3.grpc.cart.Cart;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Table(name = "orderline")
@IdClass(CompositeKey.class)
public class OrderLineDTO implements Serializable {
    @Id
    Long id;
    @Id
    String isbn;

    private int qte;

    @ManyToOne(fetch = FetchType.LAZY)
    @MapsId("isbn")
    @JoinColumn( name="isbn",
            foreignKey = @ForeignKey(
                    name="isbn",
                    foreignKeyDefinition = "FOREIGN KEY (isbn) REFERENCES book(isbn) ON UPDATE CASCADE ON DELETE CASCADE ")
    )

    private BookDTO bookDTO;

    @ManyToOne(fetch = FetchType.LAZY)
    @MapsId("id")
    @JoinColumn( name="id",
            foreignKey = @ForeignKey(
                    name="id",
                    foreignKeyDefinition = "FOREIGN KEY (id) REFERENCES orders(id) ON UPDATE CASCADE ON DELETE CASCADE ")
    )

    private OrderDTO ordersDTO;


    public OrderLineDTO(Long serialOrder, String isbnBook, int qte) {
        this.id = serialOrder;
        this.isbn = isbnBook;
        this.qte = qte;
    }
    public OrderLineDTO(){

    }

    public OrderLineDTO(String isbn, int qte) {
        this.isbn = isbn;
        this.qte = qte;
    }

    public OrderLineDTO(Long id, String isbn, int qte, BookDTO bookDTO) {
        this.id = id;
        this.isbn = isbn;
        this.qte = qte;
        this.bookDTO = bookDTO;
    }

    public int getQte() {
        return qte;
    }

    public void setQte(int qte) {
        this.qte = qte;
    }


    public BookDTO getBookDTO() {
        return bookDTO;
    }

    public void setBookDTO(BookDTO bookDTO) {
        this.bookDTO = bookDTO;
    }

    public OrderDTO getOrdersDTO() {
        return ordersDTO;
    }

    public void setOrdersDTO(OrderDTO ordersDTO) {
        this.ordersDTO = ordersDTO;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public OrderLineDTO(Long id, String isbn, int qte, BookDTO bookDTO, OrderDTO ordersDTO) {
        this.id = id;
        this.isbn = isbn;
        this.qte = qte;
        this.bookDTO = bookDTO;
        this.ordersDTO = ordersDTO;
    }

    public OrderLineDTO(OrderDTO ordersDTO, BookDTO bookDTO, int qte ) {
        this.qte = qte;
        this.id = ordersDTO.getId();
        this.isbn = bookDTO.getIsbn();
    }

    public Cart.CartOrderLine buildCartOrderLineMessage (){
        return Cart.CartOrderLine.newBuilder().setIsbn(isbn).setQte(qte).build();
    }
}
