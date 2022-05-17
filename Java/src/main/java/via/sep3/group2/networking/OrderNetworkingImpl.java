package via.sep3.group2.networking;


import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.dao.OrderDAO;
import via.sep3.group2.dao.OrdersDAO;
//import via.sep3.group2.dao.OrderDAO;


import via.sep3.group2.dao.UserDAO;
import via.sep3.group2.models.OrderDTO;
import via.sep3.grpc.order.Order;
import via.sep3.grpc.order.OrderServiceGrpc;

import java.util.List;

@GrpcService
public class OrderNetworkingImpl extends OrderServiceGrpc.OrderServiceImplBase
{
    private OrderDAO dao;
    private OrdersDAO ordersDAO;
    private UserDAO userDAO;
  //  private UserDAO userDAO;
   // private  Gson gson = new Gson();

    @Autowired
    public OrderNetworkingImpl(OrderDAO dao,OrdersDAO ordersDAO,UserDAO userDAO)
    {
        this.dao = dao;
        this.ordersDAO=ordersDAO;
        this.userDAO=userDAO;
    }

    @Override
    public void getAllOrders(Order.VoidMessage request, StreamObserver<Order.ListOrderMessage> responseObserver)
    {
      //  System.out.println(ordersDAO.getSerialOrderByUsernameAndStatus("mmm","NOTCONFIRMED"));
   //  ordersDAO.updateStatusOfOrder(1,"DELIVERED");
   //  userDAO.updateUsernameOfUser("tttt","a");
     //userDAO.createUser();
      //  long i = ordersDAO.getSerialOrderByCustomerAndStatus("a","NOTCONFIRMED");
       // UserDTO userDTO= new UserDTO("a");
      //  System.out.println(userDAO.getAllOrders(userDTO));
        List<OrderDTO> allOrders = dao.getAllOrders();
       // System.out.println(allOrders.get(0).getStatus());

        // dao object fetches all the orders
        // create a new builder object that will build your OrderMessage by building the object one by one
        Order.ListOrderMessage.Builder builder = Order.ListOrderMessage.newBuilder();

        for (OrderDTO orderDTO : allOrders)
        {
            builder.addOrders(orderDTO.buildOrderMessage());
        }

        Order.ListOrderMessage build = builder.build();
        // *****  client side *****
        /* Client side handling the return of the method call (getAllOrders)
        List<OrderDTO> ordersReturned = new ArrayList<OrderDTO>();
        for (Order.OrderMessage message : build.getOrdersList())
        {
            ordersReturned.add(new OrderDTO(message));
        }
        return ordersReturned;
        */
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }

    @Override
    public void createOrder(Order.OrderMessage request, StreamObserver<Order.VoidMessage> responseObserver)
    {
       // ordersDAO.updateStatusOfOrder(1,"anything");
        //long i=ordersDAO.getSerialOrderByCustomerAndStatus("a","NOTCONFIRMED");
       // System.out.println(i);
       // String s = gson.toJson(i);
      //  OrderDTO orderDTO = gson.fromJson(request.getOrder(), OrderDTO.class);
       // dao.createOrder(orderDTO);
        Order.VoidMessage build = Order.VoidMessage.newBuilder().build(); //always have this, you have to build the message
        // Order.VoidMessage build = Order.VoidMessage.newBuilder().setAnswer(s).build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }






}
