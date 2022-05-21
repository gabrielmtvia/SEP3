using ModelClasses;

namespace BusinessLogicServer.Networking.DummyDataForTesting;

public class DummyOrdersRepository
{
    private ICollection<UserDTO> users;
    private ICollection<OrdersDTO> orders;
    private ICollection<OrderLineDTO> orderlines;
    private ICollection<Book> books;

    private OrdersDTO order1 = new OrdersDTO(1, DateTime.Now, "CONFIRMED", "customer1");
    private OrdersDTO order2 = new OrdersDTO(2, DateTime.Now.AddDays(-1), "CONFIRMED", "customer2");
    private OrdersDTO order3 = new OrdersDTO(3, DateTime.Now.AddDays(-2), "CONFIRMED", "customer3");
    private OrdersDTO order4 = new OrdersDTO(4, DateTime.Now.AddDays(-3), "DISPATCHED", "customer4");
    private OrdersDTO order5 = new OrdersDTO(5, DateTime.Now.AddDays(-4), "DISPATCHED", "customer5");

    private UserDTO customer1 = new ("customer1", "a", "a", "a@a.a", "a", "a", "Customer", "a");
    private UserDTO customer2 = new ("customer2", "b", "b", "b@b", "b", "b", "Customer", "b");
    private UserDTO customer3 = new ("customer3", "c", "c", "c@c.c", "c", "c", "Customer", "c");
    private UserDTO customer4 = new ("customer4", "d", "d", "d@d.d", "d", "d", "Customer", "d");
    private UserDTO customer5 = new ("customer5", "e", "e", "e@e.e", "e", "e", "Customer", "e");

    private OrderLineDTO orderline1 = new OrderLineDTO(1,2,"9780345303257");
    private OrderLineDTO orderline2 = new OrderLineDTO(1,2,"9780330491198");
    private OrderLineDTO orderline3 = new OrderLineDTO(2,1,"9780606264129");
    private OrderLineDTO orderline4 = new OrderLineDTO(2,3,"900000000000003");
    private OrderLineDTO orderline5 = new OrderLineDTO(3,4,"9781451648539");

    private Book book1 = new() {Author = "Elon Musk", Edition = "1", Isbn = "11223344", Title = "A programmer becomes a billionaire."};
    private Book book2 = new() {Author = "Steve Jobs", Edition = "2", Isbn = "55667788", Title = "Biography."};
    private Book book3 = new() {Author = "Rudyard Kipling", Edition = "3", Isbn = "99101112", Title = "Jungle Book."};
    private Book book4 = new() {Author = "George Orwell", Edition = "4", Isbn = "13141516", Title = "Animal Farm."};
    private Book book5 = new() {Author = "Joseph Heller", Edition = "5", Isbn = "17181920", Title = "Catch-22."};

    public DummyOrdersRepository()
    {
        users = new[] { customer1, customer2, customer3, customer4, customer5};
        orders = new [] { order1, order2,order3, order4, order5 };
        orderlines = new[] {orderline1, orderline2, orderline3, orderline4, orderline5};
        books = new[] {book1, book2, book3, book4, book5};
    }

    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        return orders.Where(order => order.status.Equals(status)).ToList();;
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        return orders;
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return  users.FirstOrDefault(user => user.userName.Equals(orderUsername))!;
    }

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return orderlines.Where(orderline => orderline.SerialOrder == orderId).ToArray();
    }

    public async Task<ServiceResponse<Book>> GetBookByIsbnAsync(string orderlineIsbn)
    {
        ServiceResponse<Book> serviceResponse = new ServiceResponse<Book>()
        {
            Data = books.FirstOrDefault(b => b.Isbn.Equals(orderlineIsbn))
        };
        return serviceResponse;
    }
}