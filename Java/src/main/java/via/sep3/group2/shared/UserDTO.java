package via.sep3.group2.shared;

import via.sep3.grpc.order.Order;
import via.sep3.grpc.user.User;

import javax.persistence.*;
import java.io.Serializable;
import java.util.List;
import java.util.Set;

@Entity
@Table(name="users")
public class UserDTO  implements Serializable {
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
    private Set<OrderDTO> orders ;

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

    public UserDTO(String username, String password, String firstname, String lastname, String address, String phone, String email, String role, Set<OrderDTO> orders) {
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

    public UserDTO(String username, String firstname, String lastname, String address, String phone, String email) {
        this.username = username;
        this.firstname = firstname;
        this.lastname = lastname;
        this.address = address;
        this.phone = phone;
        this.email = email;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public Set<OrderDTO> getOrders() {
        return orders;
    }

    public void setOrders(Set<OrderDTO> orders) {
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

    public User.UserMessage buildUserMessage(){
       return User.UserMessage.newBuilder().setUsername(username).setPassword(password).setFirstname(firstname).setLastname(lastname)
                .setAddress(address).setPhone(phone).setEmail(email).setRole(role).build();
    }
}