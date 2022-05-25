using ModelClasses;

namespace BusinessLogicServer.Models.Cart;

public interface ICartModel
{
    Task AddCartAsync(CartLineDTO cartLineDto);
}