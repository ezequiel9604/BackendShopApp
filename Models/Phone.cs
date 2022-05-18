using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Phone 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string PhoneNumber { get; set; } = string.Empty;

    public int ClientId { get; set; }
    public Client? Client { get; set; }

}