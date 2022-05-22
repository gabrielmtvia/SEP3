package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.GenreDAO;
import via.sep3.group2.shared.GenreDTO;
import via.sep3.grpc.genre.Genre;
import via.sep3.grpc.genre.GenreServiceGrpc;

import java.util.List;

@GrpcService
public class GenreNetworkingImpl extends GenreServiceGrpc.GenreServiceImplBase {

    private GenreDAO genreDAO;

    @Autowired
    public GenreNetworkingImpl(GenreDAO genreDAO) {
        this.genreDAO = genreDAO;
    }

    @Override
    public void createGenre(Genre.GenreMessage request, StreamObserver<Genre.EmptyGenreMessage> responseObserver){

        GenreDTO genreDTO=new GenreDTO(request.getType());
        genreDAO.createGenre(genreDTO);

        Genre.EmptyGenreMessage reply= Genre.EmptyGenreMessage.newBuilder().build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();

    }

    @Override
    public void getAllGenres(Genre.EmptyGenreMessage request, StreamObserver<Genre.ListGenreMessage> responseObserver){
        List<GenreDTO> allGenres= genreDAO.getAllGenre();
        Genre.ListGenreMessage.Builder builder=Genre.ListGenreMessage.newBuilder();
        for (GenreDTO genre:allGenres
             ) {
            builder.addGenreMessage(genre.buildGenreMessage());
        }

        Genre.ListGenreMessage reply= builder.build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();
    }
}
