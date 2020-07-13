using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Model.Mappings
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            // Primary Key
            builder.HasKey(t => t.StockId);
            builder.Property(t => t.StockId).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.ProductId).IsRequired(true);
            builder.Property(t => t.Quantity).IsRequired(true);
            builder.Property(t => t.CreatedBy).HasMaxLength(50);
            builder.Property(t => t.CreatedDate);
            builder.Property(t => t.UpdatedBy).HasMaxLength(50);
            builder.Property(t => t.UpdatedDate);

            // Table & Column Mappings

            builder.ToTable("Stock");
            builder.Property(t => t.StockId).HasColumnName("StockId");
            builder.Property(t => t.ProductId).HasColumnName("ProductId");
            builder.Property(t => t.Quantity).HasColumnName("Quantity");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime");

            // Relationships
            //builder.HasOne(t => t.product)
            //    .WithMany(t => t.Stocks)
            //    .HasForeignKey(d => d.ProductId)
            //    .HasConstraintName("FK_Stocks_Product_ProductId");

        }
    }
}
