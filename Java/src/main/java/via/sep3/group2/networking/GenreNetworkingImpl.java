package via.sep3.group2.networking;

import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.GenreDAO;
import via.sep3.group2.shared.GenreDTO;
import via.sep3.grpc.genre.Genre;
import via.sep3.grpc.genre.GenreGrpcServiceGrpc;
import via.sep3.grpc.util.Util;


import java.util.List;

@GrpcService
public class GenreNetworkingImpl extends GenreGrpcServiceGrpc.GenreGrpcServiceImplBase {

    private GenreDAO genreDAO;

    @Autowired
    public GenreNetworkingImpl(GenreDAO genreDAO) {
        this.genreDAO = genreDAO;
    }

    @Override
    public void addGenre(Genre.GenreMessage request, StreamObserver<Util.VoidMessage> responseObserver)
    {
        GenreDTO genreDTO=new GenreDTO(request.getType());
        genreDAO.createGenre(genreDTO);
        Util.VoidMessage response = new Util.VoidMessage();
        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllGenre(Util.VoidMessage request, StreamObserver<Genre.ListGenreMessage> responseObserver)
    {
        List<GenreDTO> allGenre = genreDAO.getAllGenre();
        Genre.ListGenreMessage.Builder builder = Genre.ListGenreMessage.newBuilder();
        for (GenreDTO genreDTO : allGenre)
        {
            builder.addGenres(genreDTO.buildGenreMessage());
        }
        Genre.ListGenreMessage build = builder.build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();

    }

    @Override
    public void deleteGenre(Genre.GenreMessage request, StreamObserver<Util.VoidMessage> responseObserver)
    {

    }
}
