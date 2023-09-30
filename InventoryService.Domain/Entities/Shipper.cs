namespace NorthwindService.Domain.Entities;

public class Shipper : BaseEntity
{
    public string CompanyName { get; set; } = null!;
    public string? Phone { get; set; }
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
