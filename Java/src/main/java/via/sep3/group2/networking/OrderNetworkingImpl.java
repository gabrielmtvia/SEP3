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
    public void getAllOrders(Order.VoidMessage request, StreamObserver<Order.OrderMessage> responseObserver)
    {
        List<OrderDTO> allOrders = dao.getAllOrders();
        String s = gson.toJson(allOrders);

        Order.OrderMessage build = Order.OrderMessage.newBuilder().setOrder(s).build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }

    @Override
    public void createOrder(Order.OrderMessage request, StreamObserver<Order.VoidMessage> responseObserver)
    {
        OrderDTO orderDTO = gson.fromJson(request.getOrder(), OrderDTO.class);
        dao.createOrder(orderDTO);
        Order.VoidMessage build = Order.VoidMessage.newBuilder().build(); //always have this, you have to build the message
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }


}
