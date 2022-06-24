
namespace backendShopApp.Microservices.Clienting.ClientDomains.Dtos;

public class AddressDto
{
    public int Id { get; set; }

    public string StreetName { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;


    public string ClientId { get; set; } = string.Empty;

}