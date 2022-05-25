using BusinessLogicServer.Networking.Cart;
using ModelClasses;

namespace BusinessLogicServer.Models.Cart;

public class CartModel : ICartModel
{
    private ICartNetworking _cartNetworking;
    public CartModel(ICartNetworking cartNetworking)
    {
        _cartNetworking = cartNetworking;
    }

    public async Task AddCartAsync(CartLineDTO cartLineDto)
    {
        await _cartNetworking.AddCartAsync(cartLineDto);
    }
}