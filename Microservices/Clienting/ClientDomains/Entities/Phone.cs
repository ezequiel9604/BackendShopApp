﻿using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Microservices.Clienting.ClientDomains.Entities;

public class Phone
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string ClientId { get; set; } = string.Empty;
    public Client? Client { get; set; }

}