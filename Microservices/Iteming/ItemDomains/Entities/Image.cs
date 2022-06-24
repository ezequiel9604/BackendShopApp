using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Microservices.Iteming.ItemDomains.Entities;

public class Image 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Path { get; set; } = string.Empty;


    public string ItemId { get; set; } = string.Empty;
    public Item? Item { get; set; }
}