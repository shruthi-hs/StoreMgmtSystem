using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Model.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Primary Key
            builder.HasKey(t => t.ProductId);
            builder.Property(t => t.ProductId).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.ProductName).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Description).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Price).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.SKU).HasMaxLength(50);
            builder.Property(t => t.IsActive).IsRequired(true);
            builder.Property(t => t.CreatedBy).HasMaxLength(50);
            builder.Property(t => t.CreatedDate);
            builder.Property(t => t.UpdatedBy).HasMaxLength(50);
            builder.Property(t => t.UpdatedDate);

            // Table & Column Mappings

            builder.ToTable("Product");
            builder.Property(t => t.ProductId).HasColumnName("ProductId");
            builder.Property(t => t.ProductName).HasColumnName("ProductName");
            builder.Property(t => t.Description).HasColumnName("Description");
            builder.Property(t => t.Price).HasColumnName("Price");
            builder.Property(t => t.SKU).HasColumnName("SKU");
            builder.Property(t => t.IsActive).HasColumnName("IsActive");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime");

           
        }
    }
}
