package via.sep3.grpc.user;

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
    comments = "Source: User.proto")
public final class UserServiceGrpc {

  private UserServiceGrpc() {}

  public static final String SERVICE_NAME = "UserService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.user.User.UserMessage,
      via.sep3.grpc.user.User.UserMessage> getTttMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "ttt",
      requestType = via.sep3.grpc.user.User.UserMessage.class,
      responseType = via.sep3.grpc.user.User.UserMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.user.User.UserMessage,
      via.sep3.grpc.user.User.UserMessage> getTttMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.user.User.UserMessage, via.sep3.grpc.user.User.UserMessage> getTttMethod;
    if ((getTttMethod = UserServiceGrpc.getTttMethod) == null) {
      synchronized (UserServiceGrpc.class) {
        if ((getTttMethod = UserServiceGrpc.getTttMethod) == null) {
          UserServiceGrpc.getTttMethod = getTttMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.user.User.UserMessage, via.sep3.grpc.user.User.UserMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "UserService", "ttt"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.user.User.UserMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.user.User.UserMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new UserServiceMethodDescriptorSupplier("ttt"))
                  .build();
          }
        }
     }
     return getTttMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.user.User.UserMessage,
      via.sep3.grpc.user.User.UserMessage> getBbbMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "bbb",
      requestType = via.sep3.grpc.user.User.UserMessage.class,
      responseType = via.sep3.grpc.user.User.UserMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.user.User.UserMessage,
      via.sep3.grpc.user.User.UserMessage> getBbbMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.user.User.UserMessage, via.sep3.grpc.user.User.UserMessage> getBbbMethod;
    if ((getBbbMethod = UserServiceGrpc.getBbbMethod) == null) {
      synchronized (UserServiceGrpc.class) {
        if ((getBbbMethod = UserServiceGrpc.getBbbMethod) == null) {
          UserServiceGrpc.getBbbMethod = getBbbMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.user.User.UserMessage, via.sep3.grpc.user.User.UserMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "UserService", "bbb"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.user.User.UserMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.user.User.UserMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new UserServiceMethodDescriptorSupplier("bbb"))
                  .build();
          }
        }
     }
     return getBbbMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static UserServiceStub newStub(io.grpc.Channel channel) {
    return new UserServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static UserServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new UserServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static UserServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new UserServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class UserServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void ttt(via.sep3.grpc.user.User.UserMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.user.User.UserMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getTttMethod(), responseObserver);
    }

    /**
     */
    public void bbb(via.sep3.grpc.user.User.UserMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.user.User.UserMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getBbbMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getTttMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.user.User.UserMessage,
                via.sep3.grpc.user.User.UserMessage>(
                  this, METHODID_TTT)))
          .addMethod(
            getBbbMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.user.User.UserMessage,
                via.sep3.grpc.user.User.UserMessage>(
                  this, METHODID_BBB)))
          .build();
    }
  }

  /**
   */
  public static final class UserServiceStub extends io.grpc.stub.AbstractStub<UserServiceStub> {
    private UserServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private UserServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new UserServiceStub(channel, callOptions);
    }

    /**
     */
    public void ttt(via.sep3.grpc.user.User.UserMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.user.User.UserMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getTttMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void bbb(via.sep3.grpc.user.User.UserMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.user.User.UserMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getBbbMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class UserServiceBlockingStub extends io.grpc.stub.AbstractStub<UserServiceBlockingStub> {
    private UserServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private UserServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new UserServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public via.sep3.grpc.user.User.UserMessage ttt(via.sep3.grpc.user.User.UserMessage request) {
      return blockingUnaryCall(
          getChannel(), getTttMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.sep3.grpc.user.User.UserMessage bbb(via.sep3.grpc.user.User.UserMessage request) {
      return blockingUnaryCall(
          getChannel(), getBbbMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class UserServiceFutureStub extends io.grpc.stub.AbstractStub<UserServiceFutureStub> {
    private UserServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private UserServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new UserServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.user.User.UserMessage> ttt(
        via.sep3.grpc.user.User.UserMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getTttMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.user.User.UserMessage> bbb(
        via.sep3.grpc.user.User.UserMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getBbbMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_TTT = 0;
  private static final int METHODID_BBB = 1;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final UserServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(UserServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_TTT:
          serviceImpl.ttt((via.sep3.grpc.user.User.UserMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.user.User.UserMessage>) responseObserver);
          break;
        case METHODID_BBB:
          serviceImpl.bbb((via.sep3.grpc.user.User.UserMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.user.User.UserMessage>) responseObserver);
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

  private static abstract class UserServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    UserServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return via.sep3.grpc.user.User.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("UserService");
    }
  }

  private static final class UserServiceFileDescriptorSupplier
      extends UserServiceBaseDescriptorSupplier {
    UserServiceFileDescriptorSupplier() {}
  }

  private static final class UserServiceMethodDescriptorSupplier
      extends UserServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    UserServiceMethodDescriptorSupplier(String methodName) {
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
      synchronized (UserServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new UserServiceFileDescriptorSupplier())
              .addMethod(getTttMethod())
              .addMethod(getBbbMethod())
              .build();
        }
      }
    }
    return result;
  }
}
