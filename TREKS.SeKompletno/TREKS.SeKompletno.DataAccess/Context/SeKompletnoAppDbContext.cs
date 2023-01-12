using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TREKS.SeKompletno.DomainModels.Models;

namespace TREKS.SeKompletno.DataAccess.Context
{
    public class SeKompletnoAppDbContext : DbContext
    {
        public SeKompletnoAppDbContext(DbContextOptions<SeKompletnoAppDbContext> options) : base(options) { }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Manufacturer> Manfluencers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrder>()
                        .HasKey(x => new { x.ProductId, x.OrderId});

            modelBuilder.Entity<Order>()
           .HasMany(x => x.ProductOrders)
           .WithOne(x => x.Order)
           .HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<Product>()
               .HasMany(x => x.ProductOrders)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Customer>()
               .HasMany(x => x.Orders)
               .WithOne(x => x.Customer)
               .HasForeignKey(x => x.CustomerId);
            

        }



    }
}
