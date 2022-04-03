package via.sep3.group2.networking;


import com.google.gson.Gson;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import via.sep3.group2.models.OrderDTO;
import via.sep3.grpc.order.Order;
import via.sep3.grpc.order.OrderServiceGrpc;

import java.util.ArrayList;

@GrpcService
public class OrderNetworkingImpl extends OrderServiceGrpc.OrderServiceImplBase
{
    @Override
    public void getAllOrders(Order.OrderMessage request, StreamObserver<Order.OrderMessage> responseObserver)
    {
        ArrayList<OrderDTO> orders = new ArrayList<>();
        OrderDTO order = new OrderDTO(1, "Tastensen", 12.49, true);
        orders.add(order);

        Gson gson = new Gson();
        String s = gson.toJson(orders);

        Order.OrderMessage toReturn = Order.OrderMessage.newBuilder().setOrder(s).build();

        responseObserver.onNext(toReturn);
        responseObserver.onCompleted();
    }
}
