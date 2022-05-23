using ModelClasses;

namespace BusinessLogicServer.Networking.Cart;

public interface ICartNetworking
{
    Task AddCartAsync(CartLineDTO cartLineDto);
}