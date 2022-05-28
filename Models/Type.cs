using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Type 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(8)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Client> Clients { get; set; }

}