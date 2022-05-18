using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime DeliveredDate { get; set; }

    [Required]
    public double Total { get; set; }

    [Required]
    public double SubTotal { get; set; }

    [Required]
    public double Descount { get; set; }

    [Required]
    [StringLength(100)]
    public string Note { get; set; } = string.Empty;

    [Required]
    [StringLength(12)]
    public string ShipmentMethod { get; set; } = string.Empty;

    [Required]
    [StringLength(12)]
    public string PaymentMethod { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string Type { get; set; } = string.Empty;


    // FOREIGN KEYS
    public List<Purchase>? Purchases { get; set; }


    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int StatusId { get; set; }
    public Status? Status { get; set; }

}