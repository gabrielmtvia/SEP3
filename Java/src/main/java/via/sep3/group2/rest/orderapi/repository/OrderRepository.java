package via.sep3.group2.rest.orderapi.repository;

import via.sep3.group2.rest.orderapi.model.Order;
import org.springframework.stereotype.Repository;

import java.util.*;

@Repository
public class OrderRepository {
    // N/B will use SOLID later
    private static final Map<Long, Order> orderMap = new HashMap<Long, Order>();
    // assuming that data persisted to the database;
    static {
        initDataSource();
    }

    private static void initDataSource() {
        Order o1 = new Order(1L, "Exotic Sandwich for lunch", 55.00, true);
        Order o2 = new Order(2L, "Regular pizza with Pepperoni", 23.00, false);
        Order o3 = new Order(3L, "Pizza without pineapple", 35.00, true);
        Order o4 = new Order(4L, "Test order from Blazor", 35.00, true);

        orderMap.put(o1.getId(), o1);
        orderMap.put(o2.getId(), o2);
        orderMap.put(o3.getId(), o3);
        orderMap.put(o4.getId(), o4);
    }

    // CRUD R-GET
    public Order findById(long id){
        return orderMap.get(id);
    }

    // find all
    public List<Order> findAll(){
        Collection<Order> c = orderMap.values();
        List<Order> oList = new ArrayList<Order>();
        oList.addAll(c);
        return oList;
    }

    //Post-ing C --Create
    public Order save(Order order){
        orderMap.put(order.getId(), order);
        return order;
    }

    // PUTTING U --- Update

    public Order update(Order o){
        // simply save the object
        orderMap.put(o.getId(), o);
        return o;
    }

    // DELETING

    public void deleteOrder(long id){
        orderMap.remove(id);
    }
}
