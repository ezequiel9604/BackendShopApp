using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Item 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(int.MaxValue)]
    public string Description { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<SubItem>? SubItems { get; set; }
    public List<Image>? Images { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int CommentId { get; set; }
    public Comment? Comment { get; set; }
}