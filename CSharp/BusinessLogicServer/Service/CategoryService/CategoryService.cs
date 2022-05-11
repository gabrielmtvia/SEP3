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
            Name = "Historical Novels",
            Url="Historical-Novels"
        },
        new Category()
        {
            Id = 3,
            Name = "English Literature",
            Url="English-Literature"
        },
        new Category()
        {
            Id = 4,
            Name = "Hollywood Novels",
            Url = "Hollywood-Novels"
        },
        new Category()
        {
            Id = 5,
            Name = "Poetry Collections",
            Url = "Poetry"
        },
        new Category()
        {
            Id = 6,
            Name = "Novels based on comics",
            Url = "Novels-based-on-comics"
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