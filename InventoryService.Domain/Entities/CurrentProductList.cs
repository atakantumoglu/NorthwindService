namespace NorthwindService.Domain.Entities;

public class CurrentProductList : BaseEntity
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
