using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Data.EntityConfigurations
{
    public class ProductsByCategoryConfiguration : IEntityTypeConfiguration<ProductsByCategory>
    {
        public void Configure(EntityTypeBuilder<ProductsByCategory> builder)
        {
            builder
               .HasNoKey()
               .ToView("Products by Category");

            builder.Property(e => e.CategoryName).HasMaxLength(15);
            builder.Property(e => e.ProductName).HasMaxLength(40);
            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        }
    }
}
