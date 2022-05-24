using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendShopApp.Models;

public class Comment 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(8)]
    public string Id { get; set; } = string.Empty;

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