namespace ModelClasses;

public class CartLineDTO
{
    public string username { get; set; } = string.Empty;
    public List<OrderLineDTO> CartOrderLineDtos { get; set; }

    public CartLineDTO(string username, List<OrderLineDTO> cartOrderLineDtos)
    {
        this.username = username;
        CartOrderLineDtos = cartOrderLineDtos;
    }

    public CartLineDTO()
    {
        
    }
}