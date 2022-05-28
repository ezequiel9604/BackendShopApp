using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendShopApp.Models;

public class Item 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [StringLength(8)]
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(int.MaxValue)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public double Quality { get; set; }

    // FOREIGN KEYS
    public List<SubItem> SubItems { get; set; }
    public List<Image> Images { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public string? CommentId { get; set; }
    public Comment? Comment { get; set; }
}