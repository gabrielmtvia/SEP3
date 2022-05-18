using System.ComponentModel.DataAnnotations.Schema;

namespace ModelClasses;

public class ShoppingCartItem
{
    public long Isbn { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}