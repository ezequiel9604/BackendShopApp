using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Category 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Item>? Items { get; set; }
    public List<SubCategory>? SubCategories { get; set; }

}