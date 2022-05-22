package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.*;
import via.sep3.group2.shared.*;
import via.sep3.grpc.cart.Cart;
import via.sep3.grpc.cart.CartServiceGrpc;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

@GrpcService
public class CartNetworkingImpl extends CartServiceGrpc.CartServiceImplBase {
private UserDAO userDAO;
private OrderDAO ordersDAO;
private OrderLineDAO orderLineDAO;
private GenreDAO genreDAO;
private BookDAO bookDAO;

@Autowired

  /*  public CartNetworkingImpl(OrdersDAO ordersDAO, OrderLineDAO orderLineDAO, UserDAO userDAO) {
        this.ordersDAO = ordersDAO;
        this.orderLineDAO = orderLineDAO;
        this.userDAO=userDAO;
    }*/

    public CartNetworkingImpl(UserDAO userDAO, OrderDAO ordersDAO, OrderLineDAO orderLineDAO, GenreDAO genreDAO, BookDAO bookDAO) {
        this.userDAO = userDAO;
        this.ordersDAO = ordersDAO;
        this.orderLineDAO = orderLineDAO;
        this.genreDAO = genreDAO;
        this.bookDAO = bookDAO;
    }

    @Override
    public void confirmedCart(Cart.CartMessage request, StreamObserver<Cart.EmptyCartMessage> responseObserver){

        String username=request.getUsername();
        System.out.println("***********************");
        System.out.println(username);
        System.out.println("***********************");

        List<OrderLineDTO> cartOrderLine = new ArrayList<>();
        int i=0;
        for (Cart.CartOrderLine cartOrderLineProto:request.getCartOrderLineList()
             ) {
            System.out.println("++++++++++++++++++++++++++++++++++++");

            cartOrderLine.add(new OrderLineDTO(cartOrderLineProto.getIsbn(),cartOrderLineProto.getQte()));
            System.out.println( cartOrderLine.get(i).getIsbn()+", "+cartOrderLine.get(i).getQte());
            i++;
            System.out.println("++++++++++++++++++++++++++++++++++++");
        }
        //////////
        Timestamp timestamp = new Timestamp(System.currentTimeMillis());

        UserDTO userDTO= userDAO.findUserByUsername(username);

        OrderDTO order= new OrderDTO(timestamp,"Notconfirmed",userDTO);
        ordersDAO.createOrder(order);

        long id= ordersDAO.getSerialOrderByUsernameAndStatus(username,"Notconfirmed");
        System.out.println("+++++ ID+++++++++++++++++");
        System.out.println(id);

        for (OrderLineDTO orderline:cartOrderLine
             ) {
            orderLineDAO.createOrderLine(new OrderLineDTO(id,orderline.getIsbn(),orderline.getQte()));
        }

       ordersDAO.updateStatusOfOrder(id,"Confirmed");



        Cart.EmptyCartMessage reply = Cart.EmptyCartMessage.newBuilder().build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();

        ///////////////////////////////////////

        Set<GenreDTO> genres = new HashSet<>();
        GenreDTO genreDTO1=new GenreDTO("Science");
        GenreDTO genreDTO2= new GenreDTO("Drama");
        genres.add(genreDTO1);
        genres.add(genreDTO2);
        BookDTO bookDTO= new BookDTO("4","Compiler","khaled","5 th edition","compiler for biginners",12.5,"url book",genres);
        bookDAO.CreateBook(bookDTO);
    }
}
