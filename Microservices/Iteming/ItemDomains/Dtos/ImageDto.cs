
namespace backendShopApp.Microservices.Iteming.ItemDomains.Dtos;

public class ImageDto 
{
    public int Id { get; set; }

    public string Path { get; set; } = string.Empty;

    public string ItemId { get; set; } = string.Empty;
}