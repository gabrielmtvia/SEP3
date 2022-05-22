package via.sep3.group2.shared;

import javax.persistence.*;
import java.sql.Timestamp;
import java.util.List;

@Entity
@Table (name="orders")


public class OrderDTO {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private long id;
    private Timestamp date;
    private String status;

    @OneToMany(
            mappedBy = "id",fetch = FetchType.LAZY)
    //@MapsId("id")
    private List<OrderLineDTO> orderlines;

    @ManyToOne (fetch = FetchType.LAZY)
    @JoinColumn(
            name="username",
            // nullable=false,
            foreignKey = @ForeignKey(
                    name="userid",
                    foreignKeyDefinition = "FOREIGN KEY (username) REFERENCES users(username) ON UPDATE CASCADE ON DELETE CASCADE "
            )
    )
    private UserDTO user;
   // private String username;

  //  @ManyToOne (mappedBy="orders",  fetch = FetchType.LAZY)
  //  private UserDTO userDTO;

 /* @OneToMany(mappedBy = "ordersDTO")
  Set<OrdersDTO> ratings;*/

    public OrderDTO(long id, Timestamp date, String status, UserDTO user) {
        this.id = id;
        this.date = date;
        this.status = status;
        this.user = user;
    }

    public OrderDTO(Timestamp date, String status, UserDTO user) {
        this.date = date;
        this.status = status;
        this.user = user;
    }
    public OrderDTO(long id, Timestamp date, String status) {
        this.id = id;
        this.date = date;
        this.status = status;
      //  this.user = user;
    }
   /* public OrdersDTO(Date date, String status, String username) {
        this.date = date;
        this.status = status;
        this.user = username;
    }*/

    public OrderDTO(long id) {
        this.id = id;
    }

    public OrderDTO() {

    }



    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public Timestamp getDate() {
        return date;
    }

    public void setDate(Timestamp date) {
        this.date = date;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public UserDTO getUserDTO() {
        return user;
    }

    public void setUserDTO(UserDTO userDTO) {
        this.user = userDTO;
    }


    public OrderDTO(long id, Timestamp date, String status, List<OrderLineDTO> orderlines, UserDTO user) {
        this.id = id;
        this.date = date;
        this.status = status;
        this.orderlines = orderlines;
        this.user = user;
    }



    public List<OrderLineDTO> getOrderlines() {
        return orderlines;
    }

    public void setOrderlines(List<OrderLineDTO> orderlines) {
        this.orderlines = orderlines;
    }

    public UserDTO getUser() {
        return user;
    }

    public void setUser(UserDTO user) {
        this.user = user;
    }
}
