using ModelClasses;

namespace BusinessLogicServer.Networking.DummyDataForTesting;

public class DummyRepositoryDao
{
    private FileContext _fileContext;
    private DummyModelClassOfDummyRepo repo;
    public DummyRepositoryDao()
    {
        _fileContext = new FileContext();
        while (repo == null)
        {
            repo = _fileContext.DummyModelClassOfDummyRepo;   
        }
    }

    public async Task<ICollection<OrdersDTO>> GetOrdersByStatusAsync(string status)
    {
        return repo.orders.Where(order => order.status.Equals(status)).ToList();;
    }

    public async Task<ICollection<OrdersDTO>> GetAllOrdersAsync()
    {
        return repo.orders;
    }

    public async Task<UserDTO> GetCustomer(string orderUsername)
    {
        return  repo.users.FirstOrDefault(user => user.userName.Equals(orderUsername))!;
    }

    public async Task<ICollection<OrderLineDTO>> GetOrderLines(long orderId)
    {
        return repo.orderlines.Where(orderline => orderline.SerialOrder == orderId).ToArray();
    }

    public async Task<Book> GetBookByIsbnAsync(string orderlineIsbn)
    {
        return repo.books.FirstOrDefault(b => b.Isbn.Equals(orderlineIsbn));
    }

    public async Task UpdateOrderStatusAsync(long orderId, string orderStatus)
    {
        repo.orders.FirstOrDefault(o => o.id == orderId)!.status = orderStatus;
    }

    public async Task<List<Book>> getAllBooksAsync()
    {
        return repo.books.ToList();
    }
}