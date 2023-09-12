using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Data.EntityConfigurations
{
    public class ProductsAboveAveragePriceConfiguration : IEntityTypeConfiguration<ProductsAboveAveragePrice>
    {
        public void Configure(EntityTypeBuilder<ProductsAboveAveragePrice> builder)
        {
            builder
               .HasNoKey()
               .ToView("Products Above Average Price");

            builder.Property(e => e.ProductName).HasMaxLength(40);
            builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
