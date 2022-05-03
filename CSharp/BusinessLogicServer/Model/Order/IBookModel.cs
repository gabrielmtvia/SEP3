namespace BusinessLogicServer.Model.Order;

public interface IBookModel
{
    public Task<List<Book>> GetAllBooksAsync();
}