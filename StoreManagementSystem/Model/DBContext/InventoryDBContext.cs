using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Model.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Model.DBContext
{
    public class InventoryDBContext:DbContext
    {
        public InventoryDBContext()
        {

        }

        public InventoryDBContext(DbContextOptions<InventoryDBContext> options)
     : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; } 
        public virtual DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data Source=tcp:storemanagementsystemdbserver.database.windows.net,1433;Initial Catalog=InventorySystem_db;User Id=Test@storemanagementsystemdbserver;Password=Password@123");
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new StaffMap());
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.Entity<Stock>().HasIndex(u => u.ProductId).IsUnique();



            modelBuilder.Entity<Staff>().HasData(
               new Staff {StaffId = 1, Firstname = "John", Lastname = "Wick", Email = "John@gmail.com", Phone = "1234567889", CreatedBy = "test", CreatedDate = DateTime.Now },
                new Staff { StaffId = 2, Firstname = "James", Lastname = "Smith", Email = "James@gmail.com", Phone = "234353543545", CreatedBy = "test", CreatedDate = DateTime.Now },
                 new Staff { StaffId = 3, Firstname = "Joey", Lastname = "west", Email = "Joey@gmail.com", Phone = "5345345435435", CreatedBy = "test", CreatedDate = DateTime.Now }
           );

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                ProductName = "HP Laptop",
                Description = "HP Laptop",
                Price = 30000,
                SKU = "12345",
                IsActive = true,
                CreatedBy = "test",
                CreatedDate = DateTime.Now
            },
           new Product()
           {
               ProductId = 2,
               ProductName = "Dell Laptop",
               Description = "Dell Laptop",
               Price = 20000,
               SKU = "12345",
               IsActive = true,
               CreatedBy = "test",
               CreatedDate = DateTime.Now
           });

            var stock = new Stock()
            {
                StockId = 1,
                ProductId = 1,
                Quantity = 30,
                CreatedBy = "test",
                CreatedDate = DateTime.Now
            };

            var stock1 = new Stock()
            {
                StockId = 2,
                ProductId = 2,
                Quantity = 20,
                CreatedBy = "test",
                CreatedDate = DateTime.Now
            };

            modelBuilder.Entity<Stock>().HasData(stock);
            modelBuilder.Entity<Stock>().HasData(stock1);

           


            //modelBuilder.Entity<Product>(p =>
            //{
            //    p.HasData(
            //        new Product
            //        {
            //            ProductId = 1,
            //            ProductName = "HP Laptop",
            //            Description = "HP Laptop",
            //            Price = 30000,
            //            SKU = "12345",
            //            IsActive = true,
            //            CreatedBy = "test",
            //            CreatedDate = DateTime.Now
            //        });
            //    p.OwnsOne(e => e.Stocks).HasData(
            //        new { StockId = 1, ProductId = 1, Quantity = 30, CreatedBy = "test", CreatedDate = DateTime.Now });

            //    p.HasData(
            //        new Product
            //        {
            //            ProductId = 2,
            //            ProductName = "Dell Laptop",
            //            Description = "Dell Laptop",
            //            Price = 20000,
            //            SKU = "45678",
            //            IsActive = true,
            //            CreatedBy = "test",
            //            CreatedDate = DateTime.Now
            //        });
            //    p.OwnsOne(e => e.Stocks).HasData(
            //        new { StockId = 1, ProductId = 1, Quantity = 30, CreatedBy = "test", CreatedDate = DateTime.Now });
            //});



            //modelBuilder.Entity<Product>().HasData(
            //     new Product
            //     {
            //         ProductId = 1,
            //         ProductName = "HP Laptop",
            //         Description = "HP Laptop",
            //         Price = 30000,
            //         SKU = "12345",
            //         IsActive = true,
            //         CreatedBy = "test",
            //         CreatedDate = DateTime.Now,
            //         Stocks = new List<Stock>() { new Stock() { StockId = 1, ProductId = 1, Quantity = 30, CreatedBy = "test", CreatedDate = DateTime.Now } }
            //     },
            //     new Product
            //     {
            //         ProductId = 2,
            //         ProductName = "Dell Laptop",
            //         Description = "Dell Laptop",
            //         Price = 20000,
            //         SKU = "45678",
            //         IsActive = true,
            //         CreatedBy = "test",
            //         CreatedDate = DateTime.Now,
            //         Stocks = new List<Stock>() { new Stock() { StockId = 2, ProductId = 2, Quantity = 20, CreatedBy = "test", CreatedDate = DateTime.Now } }
            //     });



            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 1,
                   UserName = "manager@test.com",
                   Password="Password@123",
                   IsManager = true
               },
               new User
               {
                   UserId = 2,
                   UserName = "shopkeeper@test.com",
                   Password = "Password@123",
                   IsManager = false
               }

           );

        }

    }
}
