using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Appearance 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Client>? Clients { get; set; }
    
}