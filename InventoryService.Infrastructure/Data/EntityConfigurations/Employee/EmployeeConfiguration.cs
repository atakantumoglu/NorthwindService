﻿using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.LastName, "LastName");
            builder.HasIndex(e => e.PostalCode, "PostalCode");
            builder.Property(e => e.Address).HasMaxLength(60);
            builder.Property(e => e.BirthDate).HasColumnType("datetime");
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Extension).HasMaxLength(4);
            builder.Property(e => e.FirstName).HasMaxLength(10);
            builder.Property(e => e.HireDate).HasColumnType("datetime");
            builder.Property(e => e.HomePhone).HasMaxLength(24);
            builder.Property(e => e.LastName).HasMaxLength(20);
            builder.Property(e => e.Notes).HasColumnType("ntext");
            builder.Property(e => e.Photo).HasColumnType("image");
            builder.Property(e => e.PhotoPath).HasMaxLength(255);
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);
            builder.Property(e => e.Title).HasMaxLength(30);
            builder.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

            builder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasPrincipalKey(d => d.Id)
                .HasConstraintName("FK_Employees_Employees");

            builder.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTerritory",

                    r => r.HasOne<Territory>()
                        .WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),

                    l => l.HasOne<Employee>()
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId");
                        j.ToTable("EmployeeTerritories");
                        j.IndexerProperty<Guid>("EmployeeId").HasColumnName("EmployeeId");
                        j.IndexerProperty<Guid>("TerritoryId")
                            .HasColumnName("TerritoryId");
                    });
        }
    }
}
