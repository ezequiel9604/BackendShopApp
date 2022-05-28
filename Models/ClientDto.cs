
namespace backendShopApp.Models;

public class ClientDto 
{
    public string Id { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public int DayOfBirth { get; set; }
    
    public int MonthOfBirth { get; set; }
    
    public int YearOfBirth { get; set; }

    public string Genre { get; set; } = string.Empty;

    public AddressDto[]? AddressDtos { get; set; }
    
    public PhoneDto[]? PhoneDtos { get; set; }

    public CommentDto[]? CommentDtos { get; set; }

    public string State { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

}