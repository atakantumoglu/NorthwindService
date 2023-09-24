using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class TerritoryConfiguration : IEntityTypeConfiguration<Territory>
    {
        public void Configure(EntityTypeBuilder<Territory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RegionId);
            builder.Property(e => e.RegionId).HasColumnName("RegionId");
            builder.Property(e => e.TerritoryDescription)
                .HasMaxLength(50)
                .IsFixedLength();
            builder.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        }
    }
}
