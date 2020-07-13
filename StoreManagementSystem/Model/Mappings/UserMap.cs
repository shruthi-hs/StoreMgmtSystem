using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Model.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(t => t.UserId);
            builder.Property(t => t.UserId).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.UserName).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.Password).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.IsManager);

            // Table & Column Mappings

            builder.ToTable("User");
            builder.Property(t => t.UserName).HasColumnName("UserName");
            builder.Property(t => t.Password).HasColumnName("Password");
            builder.Property(t => t.IsManager).HasColumnName("IsManager");
        }
    }
}
