using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Data.EntityConfigurations
{
    public class SalesByCategoryConfiguration : IEntityTypeConfiguration<SalesByCategory>
    {
        public void Configure(EntityTypeBuilder<SalesByCategory> builder)
        {
            builder
                .HasNoKey()
                .ToView("Sales by Category");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.CategoryName).HasMaxLength(15);
            builder.Property(e => e.ProductName).HasMaxLength(40);
            builder.Property(e => e.ProductSales).HasColumnType("money");
        }
    }
}
