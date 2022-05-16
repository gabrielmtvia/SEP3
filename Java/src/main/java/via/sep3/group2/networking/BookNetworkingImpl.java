package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import via.sep3.group2.persistance.BookDAO;
import via.sep3.grpc.book.Book;
import via.sep3.grpc.book.BookServiceGrpc;

@GrpcService
public class BookNetworkingImpl extends BookServiceGrpc.BookServiceImplBase
{
    private BookDAO dao;

    public BookNetworkingImpl(BookDAO dao)
    {
        this.dao = dao;
    }

    @Override
    public void getAllBooks(Book.BookMessage request, StreamObserver<Book.BookMessage> responseObserver)
    {
        System.out.println(request.getBook());
        responseObserver.onNext(Book.BookMessage.newBuilder().setBook("getAllBooks - works").build());
        responseObserver.onCompleted();
    }

    @Override
    public void addBook(Book.BookMessage request, StreamObserver<Book.BookMessage> responseObserver)
    {
        dao.addBook(request.getBook());
        responseObserver.onNext(Book.BookMessage.newBuilder().setBook("addBook - works").build());
        responseObserver.onCompleted();
    }

}
