package via.sep3.group2.models;

import javax.persistence.*;
import java.io.Serializable;
import java.sql.Date;
import java.util.List;
import java.util.Set;

@Entity
@Table (name="orderss")


public class OrdersDTO {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private long id;
    private java.sql.Date date;
    private String status;

    @OneToMany(
            mappedBy = "id",fetch = FetchType.LAZY)
    //@MapsId("id")
    private List<OrderLineWithCompositeKeyDTO> orderlines;

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

    public OrdersDTO(long id, Date date, String status, UserDTO user) {
        this.id = id;
        this.date = date;
        this.status = status;
        this.user = user;
    }

    public OrdersDTO(Date date, String status, UserDTO user) {
        this.date = date;
        this.status = status;
        this.user = user;
    }
    public OrdersDTO(long id, Date date, String status) {
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

    public OrdersDTO(long id) {
        this.id = id;
    }

    public OrdersDTO() {

    }



    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
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


    public OrdersDTO(long id, Date date, String status, List<OrderLineWithCompositeKeyDTO> orderlines, UserDTO user) {
        this.id = id;
        this.date = date;
        this.status = status;
        this.orderlines = orderlines;
        this.user = user;
    }

    public List<OrderLineWithCompositeKeyDTO> getOrderlines() {
        return orderlines;
    }

    public void setOrderlines(List<OrderLineWithCompositeKeyDTO> orderlines) {
        this.orderlines = orderlines;
    }

    public UserDTO getUser() {
        return user;
    }

    public void setUser(UserDTO user) {
        this.user = user;
    }
}
