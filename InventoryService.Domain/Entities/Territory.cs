namespace NorthwindService.Domain.Entities;

public class Territory : BaseEntity
{
    public string TerritoryDescription { get; set; } = null!;
    public Guid RegionId { get; set; }
    public virtual Region Region { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

}
