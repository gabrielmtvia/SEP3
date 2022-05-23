package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.BookDAO;
import via.sep3.group2.shared.BookDTO;
import via.sep3.grpc.book.Book;
import via.sep3.grpc.book.BookGrpcServiceGrpc;
import via.sep3.grpc.util.Util;

import java.util.List;

@GrpcService
public class BookNetworkingImpl extends BookGrpcServiceGrpc.BookGrpcServiceImplBase
{
    private BookDAO dao;

    @Autowired
    public BookNetworkingImpl(BookDAO dao)
    {
        this.dao = dao;
    }

    // correct this method
    @Override
    public void getAllBooks(Util.VoidMessage request, StreamObserver<Book.ListBooksMessage> responseObserver)
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
    public void addBook(Book.BookMessage request, StreamObserver<Util.VoidMessage> responseObserver)
    {
        dao.addBook(new BookDTO(request));
        responseObserver.onNext(Util.VoidMessage.newBuilder().build());
        responseObserver.onCompleted();
    }

}
