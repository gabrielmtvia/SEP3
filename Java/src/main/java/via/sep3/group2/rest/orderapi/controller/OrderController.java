package via.sep3.group2.rest.orderapi.controller;

import via.sep3.group2.rest.orderapi.model.Order;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;
import via.sep3.group2.rest.orderapi.repository.OrderRepository;

import java.util.List;

@RestController
@RequestMapping("/")
public class OrderController {
    private OrderRepository orderRepository;

    public OrderController(OrderRepository orderRepository) {
        this.orderRepository = orderRepository;
    }


    @RequestMapping("/home")
    @ResponseBody
    public String welcome(){
        return "Welcome to the world of RESTful APIs!";
    }

    // Get-ing an order given the id

//    @RequestMapping(value="/orders",
//                    method = RequestMethod.POST,
//                    produces = {MediaType.APPLICATION_JSON_VALUE,
//                                MediaType.APPLICATION_XML_VALUE})
//    @ResponseBody
//    public Order0 createOrder(@RequestBody Order0 o){
//        System.out.println("[Backend - Server] Creating order: " + o.getId());
//        return orderRepository.save(o);
//    }

    // GET-ting all orders
    @RequestMapping (value = "/orders",
            method = RequestMethod.GET,
            produces = {//MediaType.APPLICATION_XML_VALUE,
                    MediaType.APPLICATION_JSON_VALUE})
    @ResponseBody
    public List<Order> getAllOrders() {
        return orderRepository.findAll();
    }


    // POSTing C -- Create order
    @RequestMapping (value = "/createOrder",
            method = RequestMethod.POST,
            produces = {MediaType.APPLICATION_XML_VALUE,
                    MediaType.APPLICATION_JSON_VALUE})
    @ResponseBody
    public Order createOrder(@RequestBody Order o) {
        System.out.println("[Backend - Server] Creating order: " + o.getId());
        return orderRepository.save(o);
    }

    @RequestMapping (value = "/orders/{id}",
            method = RequestMethod.PUT,
            produces = {MediaType.APPLICATION_XML_VALUE,
                    MediaType.APPLICATION_JSON_VALUE})
    @ResponseBody
    public Order updateOrder(@RequestBody Order o) {
        System.out.println("[Backend - Server] Editing order: " + o.getId());
        return orderRepository.update(o);
    }
}
