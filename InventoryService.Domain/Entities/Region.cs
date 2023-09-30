namespace NorthwindService.Domain.Entities;

public class Region : BaseEntity
{
    public string RegionDescription { get; set; } = null!;
    public virtual ICollection<Territory> Territories { get; } = new List<Territory>();
}
