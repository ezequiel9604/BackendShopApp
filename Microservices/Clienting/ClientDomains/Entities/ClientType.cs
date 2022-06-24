using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Microservices.Clienting.ClientDomains.Entities;

public class ClientType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(8)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Client>? Clients { get; set; }

}