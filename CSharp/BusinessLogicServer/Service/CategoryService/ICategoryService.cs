namespace BusinessLogicServer.Service.CategoryService;

public interface ICategoryService
{
    Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
}