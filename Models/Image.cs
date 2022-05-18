using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Image 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Path { get; set; } = string.Empty;


    public int ItemId { get; set; }
    public Item? Item { get; set; }
}