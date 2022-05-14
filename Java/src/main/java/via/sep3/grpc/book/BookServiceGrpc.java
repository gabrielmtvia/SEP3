package via.sep3.grpc.book;

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
    comments = "Source: Book.proto")
public final class BookServiceGrpc {

  private BookServiceGrpc() {}

  public static final String SERVICE_NAME = "BookService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.book.Book.BookMessage,
      via.sep3.grpc.book.Book.BookMessage> getGetAllBooksMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "getAllBooks",
      requestType = via.sep3.grpc.book.Book.BookMessage.class,
      responseType = via.sep3.grpc.book.Book.BookMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.book.Book.BookMessage,
      via.sep3.grpc.book.Book.BookMessage> getGetAllBooksMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.book.Book.BookMessage, via.sep3.grpc.book.Book.BookMessage> getGetAllBooksMethod;
    if ((getGetAllBooksMethod = BookServiceGrpc.getGetAllBooksMethod) == null) {
      synchronized (BookServiceGrpc.class) {
        if ((getGetAllBooksMethod = BookServiceGrpc.getGetAllBooksMethod) == null) {
          BookServiceGrpc.getGetAllBooksMethod = getGetAllBooksMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.book.Book.BookMessage, via.sep3.grpc.book.Book.BookMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "BookService", "getAllBooks"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.book.Book.BookMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.book.Book.BookMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new BookServiceMethodDescriptorSupplier("getAllBooks"))
                  .build();
          }
        }
     }
     return getGetAllBooksMethod;
  }

  private static volatile io.grpc.MethodDescriptor<via.sep3.grpc.book.Book.BookMessage,
      via.sep3.grpc.book.Book.BookMessage> getAddBookMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "addBook",
      requestType = via.sep3.grpc.book.Book.BookMessage.class,
      responseType = via.sep3.grpc.book.Book.BookMessage.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<via.sep3.grpc.book.Book.BookMessage,
      via.sep3.grpc.book.Book.BookMessage> getAddBookMethod() {
    io.grpc.MethodDescriptor<via.sep3.grpc.book.Book.BookMessage, via.sep3.grpc.book.Book.BookMessage> getAddBookMethod;
    if ((getAddBookMethod = BookServiceGrpc.getAddBookMethod) == null) {
      synchronized (BookServiceGrpc.class) {
        if ((getAddBookMethod = BookServiceGrpc.getAddBookMethod) == null) {
          BookServiceGrpc.getAddBookMethod = getAddBookMethod = 
              io.grpc.MethodDescriptor.<via.sep3.grpc.book.Book.BookMessage, via.sep3.grpc.book.Book.BookMessage>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "BookService", "addBook"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.book.Book.BookMessage.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  via.sep3.grpc.book.Book.BookMessage.getDefaultInstance()))
                  .setSchemaDescriptor(new BookServiceMethodDescriptorSupplier("addBook"))
                  .build();
          }
        }
     }
     return getAddBookMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static BookServiceStub newStub(io.grpc.Channel channel) {
    return new BookServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static BookServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new BookServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static BookServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new BookServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class BookServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void getAllBooks(via.sep3.grpc.book.Book.BookMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.book.Book.BookMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getGetAllBooksMethod(), responseObserver);
    }

    /**
     */
    public void addBook(via.sep3.grpc.book.Book.BookMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.book.Book.BookMessage> responseObserver) {
      asyncUnimplementedUnaryCall(getAddBookMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetAllBooksMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.book.Book.BookMessage,
                via.sep3.grpc.book.Book.BookMessage>(
                  this, METHODID_GET_ALL_BOOKS)))
          .addMethod(
            getAddBookMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                via.sep3.grpc.book.Book.BookMessage,
                via.sep3.grpc.book.Book.BookMessage>(
                  this, METHODID_ADD_BOOK)))
          .build();
    }
  }

  /**
   */
  public static final class BookServiceStub extends io.grpc.stub.AbstractStub<BookServiceStub> {
    private BookServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BookServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BookServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BookServiceStub(channel, callOptions);
    }

    /**
     */
    public void getAllBooks(via.sep3.grpc.book.Book.BookMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.book.Book.BookMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getGetAllBooksMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void addBook(via.sep3.grpc.book.Book.BookMessage request,
        io.grpc.stub.StreamObserver<via.sep3.grpc.book.Book.BookMessage> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getAddBookMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class BookServiceBlockingStub extends io.grpc.stub.AbstractStub<BookServiceBlockingStub> {
    private BookServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BookServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BookServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BookServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public via.sep3.grpc.book.Book.BookMessage getAllBooks(via.sep3.grpc.book.Book.BookMessage request) {
      return blockingUnaryCall(
          getChannel(), getGetAllBooksMethod(), getCallOptions(), request);
    }

    /**
     */
    public via.sep3.grpc.book.Book.BookMessage addBook(via.sep3.grpc.book.Book.BookMessage request) {
      return blockingUnaryCall(
          getChannel(), getAddBookMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class BookServiceFutureStub extends io.grpc.stub.AbstractStub<BookServiceFutureStub> {
    private BookServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BookServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BookServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BookServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.book.Book.BookMessage> getAllBooks(
        via.sep3.grpc.book.Book.BookMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getGetAllBooksMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<via.sep3.grpc.book.Book.BookMessage> addBook(
        via.sep3.grpc.book.Book.BookMessage request) {
      return futureUnaryCall(
          getChannel().newCall(getAddBookMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_ALL_BOOKS = 0;
  private static final int METHODID_ADD_BOOK = 1;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final BookServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(BookServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_ALL_BOOKS:
          serviceImpl.getAllBooks((via.sep3.grpc.book.Book.BookMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.book.Book.BookMessage>) responseObserver);
          break;
        case METHODID_ADD_BOOK:
          serviceImpl.addBook((via.sep3.grpc.book.Book.BookMessage) request,
              (io.grpc.stub.StreamObserver<via.sep3.grpc.book.Book.BookMessage>) responseObserver);
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

  private static abstract class BookServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    BookServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return via.sep3.grpc.book.Book.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("BookService");
    }
  }

  private static final class BookServiceFileDescriptorSupplier
      extends BookServiceBaseDescriptorSupplier {
    BookServiceFileDescriptorSupplier() {}
  }

  private static final class BookServiceMethodDescriptorSupplier
      extends BookServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    BookServiceMethodDescriptorSupplier(String methodName) {
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
      synchronized (BookServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new BookServiceFileDescriptorSupplier())
              .addMethod(getGetAllBooksMethod())
              .addMethod(getAddBookMethod())
              .build();
        }
      }
    }
    return result;
  }
}
