namespace NorthwindService.Domain.Entities;

public class Product : BaseEntity
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid? SupplierId { get; set; }
    public Guid? CategoryId { get; set; }
    public string? QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
    public virtual Category? Category { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
    public virtual Supplier? Supplier { get; set; }

}
