namespace NorthwindService.Domain.Entities;

public  class Category : BaseEntity
{
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public byte[]? Picture { get; set; }
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
