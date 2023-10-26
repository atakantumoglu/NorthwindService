using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthwindService.Domain.Entities;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Shippers");
            builder.Property(e => e.CompanyName).HasMaxLength(40);
            builder.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}
