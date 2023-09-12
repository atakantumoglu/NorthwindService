﻿namespace InventoryService.Domain.Entities;

public class Shipper : BaseEntity
{
    public int ShipperId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? Phone { get; set; }
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}