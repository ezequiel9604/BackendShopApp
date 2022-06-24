using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Microservices.Clienting.ClientDomains.Entities;

public class State
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(12)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Client>? Clients { get; set; }

}