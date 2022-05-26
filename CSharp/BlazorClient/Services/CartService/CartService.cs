using Blazored.LocalStorage;
using ModelClasses;

namespace BlazorClient.Services.CartService;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorage;
    private HttpClient _httpClient;
    
    public CartService(ILocalStorageService localStorage, HttpClient httpClient)
    {
        _localStorage = localStorage;
        _httpClient = httpClient;
    }

    public async Task AddToCart(OrderLineDTO orderLineDto, string username)
    {
        var cart = await RetrieveCart(username);
        int findBook = -1;
         findBook = cart.CartOrderLineDtos.FindIndex(p => p.Isbn == orderLineDto.Isbn);
       if (findBook == -1)
       {
           cart.CartOrderLineDtos.Add(orderLineDto);
       }
       else
       {
           cart.CartOrderLineDtos[findBook].Quantity++;
       }
       await _localStorage.SetItemAsync("cart", cart);
        
    }

    private async Task<CartLineDTO> RetrieveCart(string _username)
    {
        var cart = await _localStorage.GetItemAsync<CartLineDTO>("cart");
        if (cart == null)
        {
            cart = new CartLineDTO()
            {
                username = _username,
                CartOrderLineDtos = new List<OrderLineDTO>()
            };
        }
        else if (!cart.username.Equals(_username))
        {
            cart = new CartLineDTO()
            {
                username = _username,
                CartOrderLineDtos = new List<OrderLineDTO>()
            };
        }

        return cart;
    }

    public async Task<List<OrderLineDTO>> GetCartItems(string username)
    {
        var cart = await RetrieveCart(username);

        return cart.CartOrderLineDtos;
    }

    public async Task RemoveBookFromCart(OrderLineDTO orderLineDto, string username)
    {
        var cart = await RetrieveCart(username);
        var index = cart.CartOrderLineDtos.FindIndex(o => o.Isbn.Equals(orderLineDto.Isbn));
        cart.CartOrderLineDtos.RemoveAt(index);
        
        await _localStorage.SetItemAsync("cart", cart);
    }

    public async Task UpdateCart(OrderLineDTO orderLineDto, string username)
    {
        var cart = await RetrieveCart(username);
        var orderLine = cart.CartOrderLineDtos.Find(o => o.Isbn.Equals(orderLineDto.Isbn));
        if (orderLine != null) orderLine.Quantity = orderLineDto.Quantity;
        
        await _localStorage.SetItemAsync("cart", cart);
    }

    public async Task CheckOutCart(string _username)
    {
        var cart = await RetrieveCart(_username);
        
        //send the cart to the database
        
        var responseMessage = await _httpClient.PostAsJsonAsync("/Cart", cart);
        
        Console.WriteLine(responseMessage.ToString());
        
        //clear the shopping cart, initialize to the current user and add it to the local storage
        cart = new CartLineDTO()
        {
            username = _username,
            CartOrderLineDtos = new List<OrderLineDTO>()
        };
        
        await _localStorage.SetItemAsync("cart", cart);
    }
    
    
}