package via.sep3.grpc.order;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.15.0)",
    comments = "Source: Order.proto")
public final class OrderServiceGrpc {

  private OrderServiceGrpc() {}

  public static final String SERVICE_NAME = "OrderService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.VoidMessage,
      via.sep3.grpc.order.Order.OrderMessage> getGetAllOrdersMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "getAllOrders",
      requestType = via.sep3.grpc.order.Order.VoidMessage.class,
      responseType = via.sep3.grpc.order.Order.OrderMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.VoidMessage,
      via.sep3.grpc.order.Order.OrderMessage> getGetAllOrdersMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.VoidMessage, via.sep3.grpc.order.Order.OrderMessage> getGetAllOrdersMethod;
    if ((getGetAllOrdersMethod = OrderServiceGrpc.getGetAllOrdersMethod) == null) {
      synchronized (OrderServiceGrpc.class) {
        if ((getGetAllOrdersMethod = OrderServiceGrpc.getGetAllOrdersMethod) == null) {
          OrderServiceGrpc.getGetAllOrdersMethod = getGetAllOrdersMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.order.Order.VoidMessage, via.sep3.grpc.order.Order.OrderMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "OrderService", "getAllOrders"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.order.Order.VoidMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.order.Order.OrderMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new OrderServiceMethodDescriptorSupplier("getAllOrders"))
                  .build();
          }
        }
     }
     return getGetAllOrdersMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.OrderMessage,
      via.sep3.grpc.order.Order.VoidMessage> getCreateOrderMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "createOrder",
      requestType = via.sep3.grpc.order.Order.OrderMessage.class,
      responseType = via.sep3.grpc.order.Order.VoidMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.OrderMessage,
      via.sep3.grpc.order.Order.VoidMessage> getCreateOrderMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.OrderMessage, via.sep3.grpc.order.Order.VoidMessage> getCreateOrderMethod;
    if ((getCreateOrderMethod = OrderServiceGrpc.getCreateOrderMethod) == null) {
      synchronized (OrderServiceGrpc.class) {
        if ((getCreateOrderMethod = OrderServiceGrpc.getCreateOrderMethod) == null) {
          OrderServiceGrpc.getCreateOrderMethod = getCreateOrderMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.order.Order.OrderMessage, via.sep3.grpc.order.Order.VoidMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "OrderService", "createOrder"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.order.Order.OrderMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.order.Order.VoidMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new OrderServiceMethodDescriptorSupplier("createOrder"))
                  .build();
          }
        }
     }
     return getCreateOrderMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.IdMessage,
      via.sep3.grpc.order.Order.OrderByIdMessage> getGetAnOrderByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "getAnOrderById",
      requestType = via.sep3.grpc.order.Order.IdMessage.class,
      responseType = via.sep3.grpc.order.Order.OrderByIdMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.IdMessage,
      via.sep3.grpc.order.Order.OrderByIdMessage> getGetAnOrderByIdMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.order.Order.IdMessage, via.sep3.grpc.order.Order.OrderByIdMessage> getGetAnOrderByIdMethod;
    if ((getGetAnOrderByIdMethod = OrderServiceGrpc.getGetAnOrderByIdMethod) == null) {
      synchronized (OrderServiceGrpc.class) {
        if ((getGetAnOrderByIdMethod = OrderServiceGrpc.getGetAnOrderByIdMethod) == null) {
          OrderServiceGrpc.getGetAnOrderByIdMethod = getGetAnOrderByIdMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.order.Order.IdMessage, via.sep3.grpc.order.Order.OrderByIdMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "OrderService", "getAnOrderById"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.order.Order.IdMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.order.Order.OrderByIdMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new OrderServiceMethodDescriptorSupplier("getAnOrderById"))
                  .build();
          }
        }
     }
     return getGetAnOrderByIdMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static OrderServiceStub newStub(io.grpc.Channel channel) {
    return new OrderServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static OrderServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new OrderServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static OrderServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new OrderServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class OrderServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void getAllOrders(via.sep3.grpc.order.Order.VoidMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.OrderMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getGetAllOrdersMethod(), responseObserver);
    }

    /**
     */
    public void createOrder(via.sep3.grpc.order.Order.OrderMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.VoidMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getCreateOrderMethod(), responseObserver);
    }

    /**
     */
    public void getAnOrderById(via.sep3.grpc.order.Order.IdMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.OrderByIdMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getGetAnOrderByIdMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetAllOrdersMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.order.Order.VoidMessage,
                via.sep3.grpc.order.Order.OrderMessage>(
                  this, METHODID_GET_ALL_ORDERS)))
          .addMethod(
            getCreateOrderMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.order.Order.OrderMessage,
                via.sep3.grpc.order.Order.VoidMessage>(
                  this, METHODID_CREATE_ORDER)))
          .addMethod(
            getGetAnOrderByIdMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.order.Order.IdMessage,
                via.sep3.grpc.order.Order.OrderByIdMessage>(
                  this, METHODID_GET_AN_ORDER_BY_ID)))
          .build();
    }
  }

  /**
   */
  public static final class OrderServiceStub extends io.grpc.stub.AbstractStub<OrderServiceStub> {
    private OrderServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private OrderServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected OrderServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new OrderServiceStub(channel, callOptions);
    }

    /**
     */
    public void getAllOrders(via.sep3.grpc.order.Order.VoidMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.OrderMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getGetAllOrdersMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void createOrder(via.sep3.grpc.order.Order.OrderMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.VoidMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getCreateOrderMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getAnOrderById(via.sep3.grpc.order.Order.IdMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.OrderByIdMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getGetAnOrderByIdMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class OrderServiceBlockingStub extends io.grpc.stub.AbstractStub<OrderServiceBlockingStub> {
    private OrderServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private OrderServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected OrderServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new OrderServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public via.sep3.grpc.order.Order.OrderMessage getAllOrders(via.sep3.grpc.order.Order.VoidMessage request) {
      return blockingUnaryCall(
          getChannel(), getGetAllOrdersMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.sep3.grpc.order.Order.VoidMessage createOrder(via.sep3.grpc.order.Order.OrderMessage request) {
      return blockingUnaryCall(
          getChannel(), getCreateOrderMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.sep3.grpc.order.Order.OrderByIdMessage getAnOrderById(via.sep3.grpc.order.Order.IdMessage request) {
      return blockingUnaryCall(
          getChannel(), getGetAnOrderByIdMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class OrderServiceFutureStub extends io.grpc.stub.AbstractStub<OrderServiceFutureStub> {
    private OrderServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private OrderServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected OrderServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new OrderServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.order.Order.OrderMessage> getAllOrders(
        via.sep3.grpc.order.Order.VoidMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getGetAllOrdersMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.order.Order.VoidMessage> createOrder(
        via.sep3.grpc.order.Order.OrderMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getCreateOrderMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.order.Order.OrderByIdMessage> getAnOrderById(
        via.sep3.grpc.order.Order.IdMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getGetAnOrderByIdMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_ALL_ORDERS = 0;
  private static final int METHODID_CREATE_ORDER = 1;
  private static final int METHODID_GET_AN_ORDER_BY_ID = 2;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final OrderServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(OrderServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_ALL_ORDERS:
          serviceImpl.getAllOrders((via.sep3.grpc.order.Order.VoidMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.OrderMessage>) responseObserver);
          break;
        case METHODID_CREATE_ORDER:
          serviceImpl.createOrder((via.sep3.grpc.order.Order.OrderMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.VoidMessage>) responseObserver);
          break;
        case METHODID_GET_AN_ORDER_BY_ID:
          serviceImpl.getAnOrderById((via.sep3.grpc.order.Order.IdMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.order.Order.OrderByIdMessage>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class OrderServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    OrderServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return via.sep3.grpc.order.Order.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("OrderService");
    }
  }

  private static final class OrderServiceFileDescriptorSupplier
      extends OrderServiceBaseDescriptorSupplier {
    OrderServiceFileDescriptorSupplier() {}
  }

  private static final class OrderServiceMethodDescriptorSupplier
      extends OrderServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    OrderServiceMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (OrderServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new OrderServiceFileDescriptorSupplier())
              .addMethod(getGetAllOrdersMethod())
              .addMethod(getCreateOrderMethod())
              .addMethod(getGetAnOrderByIdMethod())
              .build();
        }
      }
    }
    return result;
  }
}
