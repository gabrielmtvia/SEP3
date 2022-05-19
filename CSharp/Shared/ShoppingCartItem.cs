using System.ComponentModel.DataAnnotations.Schema;

namespace ModelClasses;

public class ShoppingCartItem
{
    public string Isbn { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    //[Column(TypeName = "decimal(18,2)")]
    public double Price { get; set; }
    public int Quantity { get; set; }
}