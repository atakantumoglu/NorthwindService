﻿namespace InventoryService.Domain.Entities;

public class SummaryOfSalesByQuarter : BaseEntity
{
    public DateTime? ShippedDate { get; set; }
    public int OrderId { get; set; }
    public decimal? Subtotal { get; set; }
}