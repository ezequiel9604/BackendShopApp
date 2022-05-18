using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Chat 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [StringLength(8)] 
    public string Sender { get; set; } = string.Empty;

    [Required]
    public Boolean IsRead { get; set; }

    

    public int AdministratorId { get; set; }

    public Administrator? Administrator { get; set; }

    public int ClientId { get; set; }

    public Client? Client { get; set; }

}