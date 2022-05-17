package via.sep3.group2.shared;
import javax.persistence.*;
import java.io.Serializable;
import java.util.Set;

@Entity
@Table(name = "orderline")
@IdClass(CompositeKey.class)
public class OrderLineWithCompositeKeyDTO implements Serializable {
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
                    foreignKeyDefinition = "FOREIGN KEY (id) REFERENCES orderss(id) ON UPDATE CASCADE ON DELETE CASCADE ")
    )

    private OrdersDTO ordersDTO;


    public OrderLineWithCompositeKeyDTO(Long serialOrder, String isbnBook, int qte) {
        this.id = serialOrder;
        this.isbn = isbnBook;
        this.qte = qte;
    }
    public OrderLineWithCompositeKeyDTO(){

    }

  /*  public Long getSerialOrder() {
        return id;
    }

    public void setSerialOrder(Long serialOrder) {
        this.id = serialOrder;
    }

    public String getIsbnBook() {
        return isbn;
    }

    public void setIsbnBook(String isbnBook) {
        this.isbn = isbnBook;
    }*/

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

    public OrdersDTO getOrdersDTO() {
        return ordersDTO;
    }

    public void setOrdersDTO(OrdersDTO ordersDTO) {
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

    public OrderLineWithCompositeKeyDTO(Long id, String isbn, int qte, BookDTO bookDTO, OrdersDTO ordersDTO) {
        this.id = id;
        this.isbn = isbn;
        this.qte = qte;
        this.bookDTO = bookDTO;
        this.ordersDTO = ordersDTO;
    }

    public OrderLineWithCompositeKeyDTO( OrdersDTO ordersDTO,BookDTO bookDTO,int qte ) {
        this.qte = qte;
        this.id = ordersDTO.getId();
        this.isbn = bookDTO.getIsbn();
    }
}
