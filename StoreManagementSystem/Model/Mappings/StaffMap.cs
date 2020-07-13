using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Model.Mappings
{
    public class StaffMap : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            // Primary Key
            builder.HasKey(t => t.StaffId);
            builder.Property(t => t.StaffId).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.Firstname).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Lastname).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Email).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Phone).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Department).HasMaxLength(50);
            builder.Property(t => t.CreatedBy).HasMaxLength(50);
            builder.Property(t => t.CreatedDate);
            builder.Property(t => t.UpdatedBy).HasMaxLength(50);
            builder.Property(t => t.UpdatedDate);

            // Table & Column Mappings

            builder.ToTable("Staff");
            builder.Property(t => t.Firstname).HasColumnName("Firstname");
            builder.Property(t => t.Lastname).HasColumnName("Lastname");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.Phone).HasColumnName("Phone");
            builder.Property(t => t.Department).HasColumnName("Department");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            builder.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate").HasColumnType("datetime");
        }
    }
}
