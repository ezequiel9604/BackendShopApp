
namespace backendShopApp.Models;

public class ItemDto
{
    public string Id { get; set; } = string.Empty;
    
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;
    
    public string Category { get; set; } = string.Empty;
    
    public double Quality { get; set; }

    public ImageDto[]? ImageDtos { get; set; }

    public SubItemDto[]? SubItemDtos { get; set; }
    
    public CommentDto[]? CommentDtos { get; set; }

}