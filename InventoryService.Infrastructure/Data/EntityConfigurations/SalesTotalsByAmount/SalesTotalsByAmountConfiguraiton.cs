using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Data.EntityConfigurations
{
    public class SalesTotalsByAmountConfiguraiton : IEntityTypeConfiguration<SalesTotalsByAmount>
    {
        public void Configure(EntityTypeBuilder<SalesTotalsByAmount> builder)
        {
            builder
              .HasNoKey()
              .ToView("Sales Totals by Amount");

            builder.Property(e => e.CompanyName).HasMaxLength(40);
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.SaleAmount).HasColumnType("money");
            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
        }
    }
}
