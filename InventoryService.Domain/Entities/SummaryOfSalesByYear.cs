namespace NorthwindService.Domain.Entities;

public class SummaryOfSalesByYear : BaseEntity
{
    public DateTime? ShippedDate { get; set; }
    public int OrderId { get; set; }
    public decimal? Subtotal { get; set; }
}
