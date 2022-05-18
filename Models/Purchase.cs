using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Purchase 
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    [StringLength(12)]
    public string Condition { get; set; } = string.Empty;


    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int SubItemId { get; set; }
    public SubItem? SubItem { get; set; }

}