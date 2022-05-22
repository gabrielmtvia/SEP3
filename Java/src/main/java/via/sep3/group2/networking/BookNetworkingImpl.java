package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import via.sep3.group2.persistance.BookDAO;
import via.sep3.group2.shared.BookDTO;
import via.sep3.grpc.book.Book;
import via.sep3.grpc.book.BookServiceGrpc;
import via.sep3.grpc.order.Order;

import java.util.List;

@GrpcService
public class BookNetworkingImpl extends BookServiceGrpc.BookServiceImplBase
{
    private BookDAO dao;

    public BookNetworkingImpl(BookDAO dao)
    {
        this.dao = dao;
    }

    // correct this method
    @Override
    public void getAllBooks(Order.VoidMessage request, StreamObserver<Book.ListBooksMessage> responseObserver)
    {
        List<BookDTO> allOrders = dao.getAllBooks();

        responseObserver.onCompleted();
    }

    // first create the buildBookMessage() in the BookDTO class
    @Override
    public void getBookByIsbn(Book.BookByIsbn request, StreamObserver<Book.BookMessage> responseObserver)
    {
        BookDTO bookToReturn = dao.getBookByIsbn(request.getIsbn());
        Book.BookMessage bookMessage = null;
        if (bookToReturn != null)
        {
            bookMessage = bookToReturn.buildBookMessage();
        }
        responseObserver.onNext(bookMessage);
        responseObserver.onCompleted();
    }

    @Override
    public void addBook(Book.BookMessage request, StreamObserver<Order.VoidMessage> responseObserver)
    {
        dao.addBook(new BookDTO(request));
        responseObserver.onNext(Order.VoidMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

}
