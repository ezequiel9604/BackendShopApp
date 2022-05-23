using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Models;

public class Address 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string StreetName { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string State { get; set; } = string.Empty;

    
    [StringLength(30)]
    public string Department { get; set; } = string.Empty;

    [Required]
    [StringLength(5)]
    public string ZipCode { get; set; } = string.Empty;


    public int ClientId { get; set; }
    public Client? Client { get; set; }

}