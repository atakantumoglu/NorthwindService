using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Region");
            builder.Property(e => e.RegionDescription)
                .HasMaxLength(50)
                .IsFixedLength();
        }
    }
}
