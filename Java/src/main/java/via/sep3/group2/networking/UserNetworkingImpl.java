package via.sep3.group2.networking;


import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;

import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.UserDAO;
import via.sep3.group2.shared.UserDTO;
import via.sep3.grpc.user.User;
import via.sep3.grpc.user.UserServiceGrpc;


@GrpcService
public class UserNetworkingImpl extends UserServiceGrpc.UserServiceImplBase {

    private UserDAO userDAO;

    @Autowired
    public UserNetworkingImpl(UserDAO userDAO) {
        this.userDAO = userDAO;
    }
    @Override
    public void createUser(User.UserMessage request, StreamObserver<User.EmptyMessage> responseObserver){
        UserDTO userDTO=new UserDTO(request.getUsername(),request.getPassword(),request.getFirstname(),request.getLastname(),
                request.getAddress(),request.getEmail(),request.getPhone(),request.getRole()   );
        userDAO.createUser(userDTO);
        User.EmptyMessage build =  User.EmptyMessage.newBuilder().build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();

    }

    @Override
    public void login (User.LoginMessage request, StreamObserver<User.RoleMessage> roleStreamObserver){


        String role=userDAO.getRole(request.getUsername(), request.getPassword());
        if(role==null)
            role="NO_ROLE";

        // else role=userDAO.getRole(request.getUsername(), request.getPassword()

        User.RoleMessage reply= User.RoleMessage.newBuilder().setRole(role).build();
        roleStreamObserver.onNext(reply);
        roleStreamObserver.onCompleted();


    }


}