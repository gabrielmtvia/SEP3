namespace BusinessLogicServer.Service.BookService;

public interface IBookService
{
    public Task<ServiceResponse<List<Book>>> GetAllBooksAsync();
    public Task<ServiceResponse<Book>> GetBookAsync(long isbn);
    
    public Task<ServiceResponse<List<Book>>> GetBooksByCategoryAsync(string categoryUrl);
}