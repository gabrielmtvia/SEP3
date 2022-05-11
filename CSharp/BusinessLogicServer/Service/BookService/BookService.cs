using System.Net.Http.Headers;

namespace BusinessLogicServer.Service.BookService;

public class BookService : IBookService
{
    private static List<Book> _books = new List<Book>()
    {
        new Book()
        {
            Isbn = 9780345303257,
            Title = "Who Censored Roger Rabbit?",
            Author = "Gary K. Wolf",
            Description = "Who Censored Roger Rabbit? is a mystery novel written by Gary K. Wolf in 1981. It was later adapted by Disney and Amblin Entertainment into the critically acclaimed 1988 film Who Framed Roger Rabbit.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/43/CensoredRabbit.jpg",
            Price = 8.99m,
            Category = new Category()
            {
                Id = 4,
                Name = "Hollywood Novels",
                Url = "Hollywood-Novels"
            }
        },
        new Book
        {
            Isbn = 9780330491198,
            Title = "The Hitchhiker's Guide to the Galaxy",
            Author = "Douglas Adams",
            Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
            Price = 9.99m,
            Category = new Category()
            {
                Id = 1,
                Name = "Science Fiction",
                Url="Science-Fiction"
            }, 
            
        },
        new Book
        {
            Isbn = 9780606264129,
            Title = "Ready Player One",
            Author = "Ernest Cline",
            Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
            Price = 6.75m, 
            Category = new Category()
            {
                Id = 2,
                Name = "Historical Novels",
                Url="Historical-Novels"
            },
        
        },
        
        new Book
        {
            Isbn = 900000000000003,
            Title = "Nineteen Eighty-Four",
            Author = "George Orwell",
            Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/1984first.jpg",
            Price = 11.99m,
            Category = new Category()
            {
                Id = 3,
                Name = "English Literature",
                Url="English-Literature"
            }
        }
    
    };
    
    public async Task<ServiceResponse<List<ModelClasses.Book>>> GetAllBooksAsync()
    {
        var response = new ServiceResponse<List<ModelClasses.Book>>
        {
            Data = _books
        };
        return response;
    }

    public async Task<ServiceResponse<Book>> GetBookAsync(long isbn)
    {
        var response = new ServiceResponse<Book>();
        var book = _books.Find(b => b.Isbn == isbn);
        if (book == null)
        {
            response.Success = false;
            response.Message = "Sorry, but this book does not exist";
        }
        else
        {
            response.Data = book;
        }

        return response;
    }

    public async Task<ServiceResponse<List<Book>>> GetBooksByCategoryAsync(string categoryUrl)
    {
        List<Book> books = _books.Where(b => b.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToList();
        var response = new ServiceResponse<List<Book>>();

        if (books == null || books.Count == 0)
        {
            response.Message = "There are no books in this category";
            response.Success = false;
        }
        else
        {
            response.Data = books;
        }

        return response;
    }

    //TODO when books come from the third tier add await operator
    public async Task<ServiceResponse<List<Book>>> SearchBooksAsync(string searchText)
    {
        var response = new ServiceResponse<List<Book>>
        {
            Data = await FindBooksBySearchText(searchText)
        };

        return response;
    }

    private async Task<List<Book>> FindBooksBySearchText(string searchText)
    {
        return _books.Where(b => b.Title.ToLower().Contains(searchText.ToLower())
                                 ||
                                 b.Description.ToLower().Contains(searchText.ToLower())).ToList();
    }

    public async Task<ServiceResponse<List<string>>> GetBookSearchSuggestionsAsync(string searchText)
    {
        var books = await FindBooksBySearchText(searchText);
        var result = new List<string>();

        foreach (var book in books)
        {
            if (book.Title.ToLower().Contains(searchText.ToLower()))
            {
                result.Add(book.Title);
            }

            if (book.Description != null)
            {
                var punctuation = book.Description.Where(char.IsPunctuation).Distinct().ToArray();
                var words = book.Description.Split().Select(s => s.Trim(punctuation));

                foreach (var word  in words)
                {
                    if (word.ToLower().Contains(searchText.ToLower()) && !result.Contains(word))
                    {
                        result.Add(word);
                    }
                }
            }
        }

        return new ServiceResponse<List<string>>
        {
            Data = result
        };
    }
}