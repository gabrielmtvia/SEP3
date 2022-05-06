namespace BusinessLogicServer.Service.CategoryService;

public class CategoryService : ICategoryService
{
    public List<Category> Categories = new List<Category>
    {
        new Category()
        {
            Id = 1,
            Name = "Science Fiction",
            Url="Science-Fiction"
        }, 
        new Category()
        {
            Id = 2,
            Name = "History",
            Url="History"
        },
        new Category()
        {
            Id = 3,
            Name = "English Literature",
            Url="English-Literature"
        }
    };
    
    public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
    {
        return new ServiceResponse<List<Category>>
        {
            Data = Categories
        };
    }
}