using System.Text.Json;
using ModelClasses;

namespace BusinessLogicServer.Networking.DummyDataForTesting;

public class FileContext
{
    private string dummyRepoJsonFilePath = "dummyRepoJsonStorage.json";
    private DummyModelClassOfDummyRepo? dummyRepo;

    public FileContext()
    {
        //Here we check if there is already a file at the given path.
        if (File.Exists(dummyRepoJsonFilePath))
        {
            LoadDataAsync();
        }
        else
        {
            CreateFileAsync();
            Seed();
        }
    }

    private void Seed()
    {
    OrdersDTO order1 = new OrdersDTO(1, DateTime.Now, "CONFIRMED", "customer1");
    OrdersDTO order2 = new OrdersDTO(2, DateTime.Now.AddDays(-1), "CONFIRMED", "customer2");
    OrdersDTO order3 = new OrdersDTO(3, DateTime.Now.AddDays(-2), "CONFIRMED", "customer3");
    OrdersDTO order4 = new OrdersDTO(4, DateTime.Now.AddDays(-3), "DISPATCHED", "customer4");
    OrdersDTO order5 = new OrdersDTO(5, DateTime.Now.AddDays(-4), "DISPATCHED", "customer5");
    dummyRepo.orders = new [] { order1, order2,order3, order4, order5 };

    UserDTO customer1 = new ("customer1", "a", "a", "a@a.a", "a", "a", "Customer", "a");
    UserDTO customer2 = new ("customer2", "b", "b", "b@b", "b", "b", "Customer", "b");
    UserDTO customer3 = new ("customer3", "c", "c", "c@c.c", "c", "c", "Customer", "c");
    UserDTO customer4 = new ("customer4", "d", "d", "d@d.d", "d", "d", "Customer", "d");
    UserDTO customer5 = new ("customer5", "e", "e", "e@e.e", "e", "e", "Customer", "e");

    OrderLineDTO orderline1 = new OrderLineDTO(1,2,"9780345303257");
    OrderLineDTO orderline2 = new OrderLineDTO(1,2,"9780330491198");
    OrderLineDTO orderline3 = new OrderLineDTO(2,1,"9780606264129");
    OrderLineDTO orderline4 = new OrderLineDTO(2,3,"900000000000003");
    OrderLineDTO orderline5 = new OrderLineDTO(3,4,"9781451648539");

    Book book1 = new() {Author = "Elon Musk", Edition = "1", Isbn = "9780345303257", Title = "A programmer becomes a billionaire.", Description = "Descr1",Price = 10.99, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/43/CensoredRabbit.jpg"};
    Book book2 = new() {Author = "Steve Jobs", Edition = "2", Isbn = "9780330491198", Title = "Biography.", Description = "Descr2",Price = 11.99, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg"};
    Book book3 = new() {Author = "Rudyard Kipling", Edition = "3", Isbn = "9780606264129", Title = "Jungle Book.", Description = "Descr3",Price = 12.99, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg"};
    Book book4 = new() {Author = "George Orwell", Edition = "4", Isbn = "900000000000003", Title = "Animal Farm.", Description = "Descr4",Price = 13.99, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg"};
    Book book5 = new() {Author = "Joseph Heller", Edition = "5", Isbn = "9781451648539", Title = "Catch-22.", Description = "Descr5",Price = 14.99, ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e4/Steve_Jobs_by_Walter_Isaacson.jpg"};
    
    dummyRepo.users = new[] { customer1, customer2, customer3, customer4, customer5};
    dummyRepo.orderlines = new[] {orderline1, orderline2, orderline3, orderline4, orderline5};
    dummyRepo.books = new[] {book1, book2, book3, book4, book5};
    SaveChangesAsync();
    }

    private async Task CreateFileAsync()
    {
        dummyRepo = new DummyModelClassOfDummyRepo();
        Seed();
        await SaveChangesAsync();
    }

    public DummyModelClassOfDummyRepo DummyModelClassOfDummyRepo
    {
        get
        {
            if (dummyRepo == null)
            {
                Task.FromResult(LoadDataAsync());
            }

            return dummyRepo!;
        }
    }
    
    private async Task LoadDataAsync()
    {
        string content = await File.ReadAllTextAsync(dummyRepoJsonFilePath);
        dummyRepo = JsonSerializer.Deserialize<DummyModelClassOfDummyRepo>(content);
    }
    
    public async Task SaveChangesAsync()
    {
        string serialized = JsonSerializer.Serialize(DummyModelClassOfDummyRepo, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        await File.WriteAllTextAsync(dummyRepoJsonFilePath, serialized);
    }
}
