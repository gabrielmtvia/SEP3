package via.sep3.group2.models;

import javax.persistence.*;
import java.io.Serializable;
import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name="users")
public class UserDTO implements Serializable {
    @Id
   // @Column(name = "userid")
    private String username;
    private String password;
    private java.sql.Date birthday;
    private String role;

    //@OneToOne(cascade=CascadeType.PERSIST)
   /* @OneToMany(cascade = CascadeType.ALL,
            mappedBy = "userDTO",
            orphanRemoval = true)*/
          //  mappedBy = "userDTO", orphanRemoval = true)
    @OneToMany ( cascade = CascadeType.ALL,
            mappedBy = "user",orphanRemoval = true
           )

   // @JoinColumn(name="username")
    private List<OrdersDTO> orders ;



    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public List<OrdersDTO> getOrders() {
        return orders;
    }

    public void setOrders(List<OrdersDTO> orders) {
        this.orders = orders;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Date getBirthday() {
        return birthday;
    }

    public void setBirthday(Date birthday) {
        this.birthday = birthday;
    }
}