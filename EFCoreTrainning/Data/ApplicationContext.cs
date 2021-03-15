using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreTrainning.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=EFCoreTrainning;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(p =>
            {
                p.ToTable("Customers");
                p.HasKey(p => p.Id);
                p.Property(p => p.Name).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Phone).HasColumnType("CHAR(9)");
                p.Property(p => p.PostCode).HasColumnType("CHAR(4)").IsRequired();
                p.Property(p => p.State).HasColumnType("VARCHAR(30)").IsRequired();
                p.Property(p => p.City).HasMaxLength(60).IsRequired();

                p.HasIndex(i => i.Phone).HasName("idx_customer_phone");
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products");
                p.HasKey(p => p.Id);
                p.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(p => p.Description).HasColumnType("VARCHAR(60)");
                p.Property(p => p.Amount).IsRequired();
                p.Property(p => p.ProductType).HasConversion<string>();
            });

            modelBuilder.Entity<Order>(p =>
            {
                p.ToTable("Orders");
                p.HasKey(p => p.Id);
                p.Property(p => p.StartDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                p.Property(p => p.EndDate).HasColumnType("CHAR(9)");
                p.Property(p => p.OrderStatus).HasConversion<string>();
                p.Property(p => p.ShippingType).HasConversion<int>();
                p.Property(p => p.Comments).HasColumnType("VARCHAR(512)");

                p.HasMany(p => p.OrderItems)
                    .WithOne(p => p.Order)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<OrderItem>(p =>
            {
                p.ToTable("OrderItems");
                p.HasKey(p => p.Id);
                p.Property(p => p.Quantity).HasDefaultValue(1).IsRequired();
                p.Property(p => p.Amount).IsRequired();
                p.Property(p => p.Discount).IsRequired();
            });
        }

    }
}