
namespace backendShopApp.Microservices.Commenting.CommentDomains.Dtos;

public class CommentDto
{
    public string Id { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public DateTime Date { get; set; }


    public string ClientId { get; set; } = string.Empty;

    public string ItemId { get; set; } = string.Empty;

}