using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Currancy 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(16)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Client>? Clients { get; set; }
}