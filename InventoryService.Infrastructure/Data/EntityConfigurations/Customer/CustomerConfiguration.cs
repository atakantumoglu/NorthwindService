using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.City, "City");
            builder.HasIndex(e => e.CompanyName, "CompanyName");
            builder.HasIndex(e => e.PostalCode, "PostalCode");
            builder.HasIndex(e => e.Region, "Region");
            builder.Property(e => e.Address).HasMaxLength(60);
            builder.Property(e => e.City).HasMaxLength(15);
            builder.Property(e => e.CompanyName).HasMaxLength(40);
            builder.Property(e => e.ContactName).HasMaxLength(30);
            builder.Property(e => e.ContactTitle).HasMaxLength(30);
            builder.Property(e => e.Country).HasMaxLength(15);
            builder.Property(e => e.Fax).HasMaxLength(24);
            builder.Property(e => e.Phone).HasMaxLength(24);
            builder.Property(e => e.PostalCode).HasMaxLength(10);
            builder.Property(e => e.Region).HasMaxLength(15);
        }
    }
}
