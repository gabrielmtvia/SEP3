using ModelClasses;

namespace BusinessLogicServer.Networking.DummyDataForTesting;

public class DummyModelClassOfDummyRepo
{
    public ICollection<UserDTO> users { get; set; }
    public  ICollection<OrdersDTO> orders  { get; set; }
    public  ICollection<OrderLineDTO> orderlines  { get; set; }
    public  ICollection<Book> books  { get; set; }

    public DummyModelClassOfDummyRepo()
    {
        users = new List<UserDTO>();
        orders = new List<OrdersDTO>();
        orderlines = new List<OrderLineDTO>();
        books = new List<Book>();
    }
}