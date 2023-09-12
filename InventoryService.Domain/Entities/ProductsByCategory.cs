﻿namespace NorthwindService.Domain.Entities;

public class ProductsByCategory : BaseEntity
{
    public string CategoryName { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string? QuantityPerUnit { get; set; }
    public short? UnitsInStock { get; set; }
    public bool Discontinued { get; set; }
}
