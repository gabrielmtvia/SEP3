package via.sep3.group2.networking;


import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.dao.OrderDAO;
import via.sep3.group2.models.OrderDTO;
import via.sep3.grpc.order.Order;
import via.sep3.grpc.order.OrderServiceGrpc;

import java.util.ArrayList;
import java.util.List;

@GrpcService
public class OrderNetworkingImpl extends OrderServiceGrpc.OrderServiceImplBase
{
    private OrderDAO dao;
    private  Gson gson = new Gson();

    @Autowired
    public OrderNetworkingImpl(OrderDAO dao)
    {
        this.dao = dao;
    }

    @Override
    public void getAllOrders(Order.VoidMessage request, StreamObserver<Order.ListOrderMessage> responseObserver)
    {
        List<OrderDTO> allOrders = dao.getAllOrders();

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
        OrderDTO orderDTO = new OrderDTO(request);
        dao.createOrder(orderDTO);
        Order.VoidMessage build = Order.VoidMessage.newBuilder().build(); //always have this, you have to build the response message
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }


}
