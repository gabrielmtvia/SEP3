package via.sep3.group2;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import via.sep3.grpc.order.OrderServiceGrpc;

@SpringBootApplication
public class DataServerApplication {
    public static void main(String[] args) {
        SpringApplication.run(DataServerApplication.class, args);
    }
}