using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class SubItem 
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public double Descount { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public double Quality { get; set; }
    
    [Required]
    [StringLength(10)]
    public string State { get; set; } = string.Empty;
    
    [Required]
    [StringLength(20)]
    public string Color { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Size { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Capacity { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<ShoppingCart>? ShoppingCarts { get; set; }
    public List<WishList>? WishLists { get; set; }
    public List<Purchase>? Purchases { get; set; }

}