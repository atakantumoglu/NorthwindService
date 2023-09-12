﻿using NorthwindService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthwindService.Infrastructure.Data.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.HasIndex(e => e.CategoryName, "CategoryName");
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
            builder.Property(e => e.CategoryName).HasMaxLength(15);
            builder.Property(e => e.Description).HasColumnType("ntext");
            builder.Property(e => e.Picture).HasColumnType("image");
        }
    }
}
