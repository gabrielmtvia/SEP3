using Blazored.LocalStorage;
using ModelClasses;

namespace BlazorClient.Services.CartService;

public class CartService2 : ICartService2
{
    private readonly ILocalStorageService _localStorage;
    
    public CartService2(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task AddToCart(OrderLineDTO orderLineDto, string username)
    {
        var cart = await RetrieveCart(username);

        cart.CartList.Add(orderLineDto);

        await _localStorage.SetItemAsync("cart", cart);
    }

    private async Task<ShoppingCart> RetrieveCart(string username)
    {
        var cart = await _localStorage.GetItemAsync<ShoppingCart>("cart");
        if (cart == null)
        {
            cart = new ShoppingCart()
            {
                Username = username,
                CartList = new List<OrderLineDTO>()
            };
        }
        else if (!cart.Username.Equals(username))
        {
            cart = new ShoppingCart()
            {
                Username = username,
                CartList = new List<OrderLineDTO>()
            };
        }

        return cart;
    }

    public async Task<List<OrderLineDTO>> GetCartItems(string username)
    {
        var cart = await RetrieveCart(username);

        return cart.CartList;
    }

    public async Task RemoveBookFromCart(OrderLineDTO orderLineDto, string username)
    {
        var cart = await RetrieveCart(username);
        var index = cart.CartList.FindIndex(o => o.Isbn.Equals(orderLineDto.Isbn));
        cart.CartList.RemoveAt(index);
        
        await _localStorage.SetItemAsync("cart", cart);
    }

    public async Task UpdateCart(OrderLineDTO orderLineDto, string username)
    {
        var cart = await RetrieveCart(username);
        var orderline = cart.CartList.Find(o => o.Isbn.Equals(orderLineDto.Isbn));
        if (orderline != null) orderline.Quantity = orderLineDto.Quantity;
        
        await _localStorage.SetItemAsync("cart", cart);
    }

    public async Task CheckOutCart(string username)
    {
        var cart = await RetrieveCart(username);
        
        //send the cart to the database
        
        //clear the shopping cart, initialize to the current user and add it to the local storage
        cart = new ShoppingCart()
        {
            Username = username,
            CartList = new List<OrderLineDTO>()
        };
        
        await _localStorage.SetItemAsync("cart", cart);
    }
}