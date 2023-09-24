﻿using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.CustomerId, "CustomerId");
            builder.HasIndex(e => e.CustomerId, "CustomersOrders");
            builder.HasIndex(e => e.EmployeeId, "EmployeeId");
            builder.HasIndex(e => e.EmployeeId, "EmployeesOrders");
            builder.HasIndex(e => e.OrderDate, "OrderDate");
            builder.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");
            builder.HasIndex(e => e.ShippedDate, "ShippedDate");
            builder.HasIndex(e => e.ShipperId, "ShippersOrders");
            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId");
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(e => e.Freight)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            builder.Property(e => e.OrderDate).HasColumnType("datetime");
            builder.Property(e => e.RequiredDate).HasColumnType("datetime");
            builder.Property(e => e.ShipAddress).HasMaxLength(60);
            builder.Property(e => e.ShipCity).HasMaxLength(15);
            builder.Property(e => e.ShipCountry).HasMaxLength(15);
            builder.Property(e => e.ShipName).HasMaxLength(40);
            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);
            builder.Property(e => e.ShipRegion).HasMaxLength(15);
            builder.Property(e => e.ShippedDate).HasColumnType("datetime");

            builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");

            builder.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipperId)
                .HasConstraintName("FK_Orders_Shippers");
        }
    }
}
