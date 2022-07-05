using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Microservices.Iteming.ItemDomains.Entities;

public class SubCategory 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;


    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}