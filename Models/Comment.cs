using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Comment 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(int.MaxValue)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [StringLength(8)]
    public string State { get; set; } = string.Empty;


    // FOREIGN KEYS
    public List<Item>? Items { get; set; }
    public List<Client>? Clients { get; set; }
}