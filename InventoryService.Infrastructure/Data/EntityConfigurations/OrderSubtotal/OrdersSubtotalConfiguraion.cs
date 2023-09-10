using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Data.EntityConfigurations
{
    public class OrdersSubtotalConfiguraion : IEntityTypeConfiguration<OrderSubtotal>
    {
        public void Configure(EntityTypeBuilder<OrderSubtotal> builder)
        {
            builder
               .HasNoKey()
               .ToView("Order Subtotals");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}
