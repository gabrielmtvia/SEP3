package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.OrderDAO;
import via.sep3.group2.persistance.OrderLineDAO;
import via.sep3.group2.persistance.UserDAO;
import via.sep3.group2.shared.JoinDTO;
import via.sep3.group2.shared.OrderDTO;
import via.sep3.group2.shared.UserDTO;
import via.sep3.grpc.order.Order;
import via.sep3.grpc.order.OrderServiceGrpc;

import java.util.List;

@GrpcService
public class OrderNetworkingImpl extends OrderServiceGrpc.OrderServiceImplBase {
    private OrderDAO orderDAO;
    private OrderLineDAO orderLineDAO;
    private UserDAO userDAO;
    @Autowired
    public OrderNetworkingImpl(OrderDAO orderDAO, OrderLineDAO orderLineDAO,UserDAO userDAO ) {
        this.orderDAO = orderDAO;
        this.orderLineDAO = orderLineDAO;
        this.userDAO=userDAO;
    }
    @Override
    public void getAllOrders(Order.EmptyOrderMessage request, StreamObserver<Order.ListOfOrdersMessage> responseObserver){
        List<OrderDTO> orderDTOS= orderDAO.getAllOrders();
        Order.ListOfOrdersMessage.Builder builder=Order.ListOfOrdersMessage.newBuilder();
       // Order.OrderUserMessage.Builder builderUser=Order.OrderUserMessage.newBuilder();
        for (OrderDTO o:orderDTOS
        ) {

            builder.addOrders(o.buildOrderMessage());
        }
        Order.ListOfOrdersMessage reply=builder.build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();
    }
    @Override
    public void getCustomerOrder(Order.OrderUsername request,StreamObserver<Order.OrderUserMessage> responseObserver){
        UserDTO userDTO= userDAO.findUserByUsername(request.getUsername());
        Order.OrderUserMessage.Builder builder=Order.OrderUserMessage.newBuilder();
        Order.OrderUserMessage reply= builder.setUsername(userDTO.getUsername()).setFirstname(userDTO.getFirstname()).setLastname(userDTO.getLastname())
                .setAddress(userDTO.getAddress()).setPhone(userDTO.getPhone()).setEmail(userDTO.getEmail()).build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();

    }
    @Override
    public void getOrdersByStatus(Order.OrdersByStatusMessage request, StreamObserver<Order.ListOfOrdersMessage> responseObserver){
        List<OrderDTO> orderDTOS=orderDAO.getAllOrdersByStatus(request.getStatus());
        Order.ListOfOrdersMessage.Builder builder=Order.ListOfOrdersMessage.newBuilder();
        // Order.OrderUserMessage.Builder builderUser=Order.OrderUserMessage.newBuilder();
        for (OrderDTO o:orderDTOS
        ) {

            builder.addOrders(o.buildOrderMessage());
        }
        Order.ListOfOrdersMessage reply=builder.build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();
    }

    @Override
    public void getOrderLine(Order.OrderIDMessage request, StreamObserver<Order.ListOrderLineMessage> responseObserver){

        List<JoinDTO> orderLineList= orderLineDAO.getAllTheBooksOfAnOrder(request.getId());
        Order.ListOrderLineMessage.Builder builder= Order.ListOrderLineMessage.newBuilder();

        for (JoinDTO j:orderLineList
             ) {
            builder.addOrderLineMessage(j.buildOrderLineMessage());
        }
        Order.ListOrderLineMessage reply = builder.build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();
    }

    @Override
    public void updateOrderStatus(Order.ChangeStatusOfOrder request, StreamObserver<Order.EmptyOrderMessage> responseObserver){

        orderDAO.updateStatusOfOrder(request.getId(),request.getStatus());

        Order.EmptyOrderMessage reply= Order.EmptyOrderMessage.newBuilder().build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();

    }

    @Override
    public void getAllOrdersByUserName(Order.OrderUsername request, StreamObserver<Order.ListOfOrdersMessage> responseObserver){

        List<OrderDTO> orderDTOS=orderDAO.getOrdersByUsername(request.getUsername());
        Order.ListOfOrdersMessage.Builder builder=Order.ListOfOrdersMessage.newBuilder();
        // Order.OrderUserMessage.Builder builderUser=Order.OrderUserMessage.newBuilder();
        for (OrderDTO o:orderDTOS
        ) {

            builder.addOrders(o.buildOrderMessage());
        }
        Order.ListOfOrdersMessage reply=builder.build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();

    }

}
