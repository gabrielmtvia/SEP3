package via.sep3.group2.models;

import javax.persistence.*;
import java.io.Serializable;
import java.sql.Date;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name="users")
public class UserDTO  {
    @Id
   // @Column(name = "userid")
    private String username;
    private String password;
   // private java.sql.Date birthday;
    private String firstname;
    private String lastname;
    private String address;
    private String phone;
    private String email;
    private String role;

    //@OneToOne(cascade=CascadeType.PERSIST)
   /* @OneToMany(cascade = CascadeType.ALL,
            mappedBy = "userDTO",
            orphanRemoval = true)*/
          //  mappedBy = "userDTO", orphanRemoval = true)
    @OneToMany ( cascade = CascadeType.ALL,
            mappedBy = "user",orphanRemoval = true
           )
    private List<OrdersDTO> orders ;

    public UserDTO(String username, String password, String role) {
        this.username = username;
        this.password = password;
        this.role = role;
    }

    public UserDTO(String username, String password, String firstname, String lastname, String address, String phone, String email, String role) {
        this.username = username;
        this.password = password;
       // this.birthday = birthday;
        this.firstname = firstname;
        this.lastname = lastname;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.role = role;
    }

    public UserDTO(String username, String password, String firstname, String lastname, String address, String phone, String email, String role, List<OrdersDTO> orders) {
        this.username = username;
        this.password = password;
        //this.birthday = birthday;
        this.firstname = firstname;
        this.lastname = lastname;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.role = role;
        this.orders = orders;
    }

    public UserDTO(String username) {
        this.username = username;
    }

    public UserDTO() {

    }


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



    public String getFirstname() {
        return firstname;
    }

    public void setFirstname(String firstname) {
        this.firstname = firstname;
    }

    public String getLastname() {
        return lastname;
    }

    public void setLastname(String lastname) {
        this.lastname = lastname;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String mail) {
        this.email = mail;
    }
}