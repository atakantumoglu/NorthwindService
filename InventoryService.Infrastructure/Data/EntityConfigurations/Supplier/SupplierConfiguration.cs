using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.CompanyName, "CompanyName");
            builder.HasIndex(e => e.PostalCode, "PostalCode");
            builder.Property(e => e.Address).HasMaxLength(60);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.CompanyName).HasMaxLength(40);
            builder.Property(e => e.ContactName).HasMaxLength(30);
            builder.Property(e => e.ContactTitle).HasMaxLength(30);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Fax).HasMaxLength(24);
            builder.Property(e => e.HomePage).HasColumnType("ntext");
            builder.Property(e => e.Phone).HasMaxLength(24);
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);
        }
    }
}
