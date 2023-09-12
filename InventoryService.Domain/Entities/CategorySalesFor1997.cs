namespace NorthwindService.Domain.Entities;

public class CategorySalesFor1997 : BaseEntity
{
    public string CategoryName { get; set; } = null!;

    public decimal? CategorySales { get; set; }
}
