﻿using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class OrderDetailsExtendedConfiguration : IEntityTypeConfiguration<OrderDetailsExtended>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsExtended> builder)
        {
            builder
                  .HasNoKey()
                  .ToView("Order Details Extended");

            builder.Property(e => e.ExtendedPrice).HasColumnType("money");
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.ProductId).HasColumnName("ProductID");
            builder.Property(e => e.ProductName).HasMaxLength(40);
            builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
