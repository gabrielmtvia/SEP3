namespace BlazorClient.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategoriesAsync();
}