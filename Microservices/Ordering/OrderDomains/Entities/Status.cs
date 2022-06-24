﻿using System.ComponentModel.DataAnnotations;

namespace backendShopApp.Microservices.Ordering.OrderDomains.Entities;

public class Status
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; } = string.Empty;

    // FOREIGN KEYS
    public List<Order>? Orders { get; set; }

}