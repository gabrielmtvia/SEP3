package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.BookDAO;
import via.sep3.group2.shared.BookDTO;
import via.sep3.grpc.book.Book;
import via.sep3.grpc.book.BookServiceGrpc;
import via.sep3.grpc.user.User;

@GrpcService
public class BookNetworkingImpl extends BookServiceGrpc.BookServiceImplBase {

    private BookDAO bookDAO;

    @Autowired
    public BookNetworkingImpl(BookDAO bookDAO) {
        this.bookDAO = bookDAO;
    }

    @Override
    public void createBook(Book.BookMessage request, StreamObserver<Book.EmptyBookMessage> responseObserver){

        BookDTO bookDTO= new BookDTO(request.getIsbn(),request.getTitle(),request.getAuthor(),request.getEdition(),request.getDescription()
                                    ,request.getPrice(),request.getUrl());
        bookDAO.CreateBook(bookDTO);
        Book.EmptyBookMessage reply = Book.EmptyBookMessage.newBuilder().build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();
    }

}
