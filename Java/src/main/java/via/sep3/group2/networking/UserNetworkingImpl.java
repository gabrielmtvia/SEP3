package via.sep3.group2.networking;


import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;

import org.springframework.beans.factory.annotation.Autowired;
import via.sep3.group2.persistance.IUserDAO;
import via.sep3.group2.persistance.OrderLineDAO;
import via.sep3.group2.persistance.UserDAO;
import via.sep3.group2.shared.BookDTO;
import via.sep3.group2.shared.OrderLineDTO;
import via.sep3.group2.shared.UserDTO;
import via.sep3.grpc.user.User;
import via.sep3.grpc.user.UserServiceGrpc;

import java.sql.SQLOutput;
import java.util.List;
import java.util.Set;


@GrpcService
public class UserNetworkingImpl extends UserServiceGrpc.UserServiceImplBase {

    private IUserDAO userDAO;
  //  private OrderLineDAO orderLineDAO;

    @Autowired
    public UserNetworkingImpl(IUserDAO userDAO/*,OrderLineDAO orderLineDAO*/) {
        this.userDAO = userDAO;
      //  this.orderLineDAO=orderLineDAO;
    }
    @Override
    public void createUser(User.UserMessage request, StreamObserver<User.EmptyMessage> responseObserver){
        UserDTO userDTO=new UserDTO(request.getUsername(),request.getPassword(),request.getFirstname(),request.getLastname(),
                request.getAddress(),request.getPhone(),request.getEmail(),request.getRole()   );
        userDAO.createUser(userDTO);
        User.EmptyMessage build =  User.EmptyMessage.newBuilder().build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();

    }

    @Override
    public void login (User.LoginMessage request, StreamObserver<User.RoleMessage> roleStreamObserver){


        String role=userDAO.getRole(request.getUsername(), request.getPassword());
     /*   if(role==null)
            role="NO_ROLE";*/

        // else role=userDAO.getRole(request.getUsername(), request.getPassword()

        User.RoleMessage reply= User.RoleMessage.newBuilder().setRole(role).build();

        roleStreamObserver.onNext(reply);
        roleStreamObserver.onCompleted();
       /*
        UserDTO user=new UserDTO("Khaled","123456","Khaled","Djamel","fdfdf","12345678","Khaled@gmail.com","anything");
        userDAO.updateUser("Djamel",user);
        */

     /*   System.out.println("**********---------No Join----**********************");
        long i=4;
        List<OrderLineDTO> ordelines=orderLineDAO.getAllBooksByIdWithoutJoin(i);
        for (OrderLineDTO o:ordelines
        ) {
            System.out.println(o.getId()+", "+o.getIsbn()+", "+o.getQte()+", "+o.getBookDTO().toString());

        }
        System.out.println("**********---------No Join----**********************");*/

    }

    @Override
    public void getUsersByRole(User.TypeOfUsersMessage request, StreamObserver<User.ListOfUsers> responseObserver){

        List<UserDTO> users=userDAO.getUsersByRole(request.getRole());

        User.ListOfUsers.Builder builder= User.ListOfUsers.newBuilder();

        for (UserDTO u: users
             ) {
            builder.addUserMessage(u.buildUserMessage());
        }
        User.ListOfUsers reply= builder.build();

        responseObserver.onNext(reply);
        responseObserver.onCompleted();


    }
    @Override
    public void deleteUser(User.UserNameMessage request, StreamObserver<User.EmptyMessage> responseObserver){
        userDAO.deleteUser(request.getUsername());
        User.EmptyMessage build =  User.EmptyMessage.newBuilder().build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }

    @Override
    public void isUserExists(User.UserNameMessage request, StreamObserver<User.UsernameExists> responseObserver){
        boolean findOut= userDAO.isUserExist(request.getUsername());
        User.UsernameExists reply = User.UsernameExists.newBuilder().setExist(findOut).build();
        responseObserver.onNext(reply);
        responseObserver.onCompleted();
    }

    @Override
    public void updateUser(User.UpdateUserMessage request, StreamObserver<User.EmptyMessage> responseObserver){


        UserDTO userDTO= new UserDTO(request.getUserToBeUpdated().getUsername(),request.getUserToBeUpdated().getPassword(),request.getUserToBeUpdated().getFirstname()
                                    ,request.getUserToBeUpdated().getLastname(),request.getUserToBeUpdated().getAddress(),request.getUserToBeUpdated().getPhone()
        ,request.getUserToBeUpdated().getEmail(),request.getUserToBeUpdated().getRole());

        userDAO.updateUser(request.getUsername(),userDTO);
        User.EmptyMessage build =  User.EmptyMessage.newBuilder().build();
        responseObserver.onNext(build);
        responseObserver.onCompleted();
    }

}