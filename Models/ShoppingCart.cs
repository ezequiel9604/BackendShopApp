using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class ShoppingCart 
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Amount { get; set; }


    public int SubItemId { get; set; }
    public SubItem? SubItem { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

}