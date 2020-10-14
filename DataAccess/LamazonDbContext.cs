using DomainModels.Enums;
using DomainModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class LamazonDbContext : IdentityDbContext<User>
    {
        public LamazonDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.ProductId, op.OrderId });
                

            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(op => op.Order)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId);

            builder.Entity<Invoice>()
                .HasOne(i => i.Order)
                .WithOne();

            string adminRoleID = Guid.NewGuid().ToString();
            string supplierRoleID = Guid.NewGuid().ToString();
            string customerRoleID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleID, Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = customerRoleID, Name = "customer", NormalizedName = "CUSTOMER" }
                );


            //seeding the admin user with admin role
            string adminId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    FullName = "TheMan",
                    UserName = "theman",
                    NormalizedUserName = "THEMAN",
                    Email = "theman@theman.com",
                    NormalizedEmail = "THEMAN@THEMAN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "fuck007"),
                    SecurityStamp = string.Empty
                }
                );


               builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string> { UserId = adminId, RoleId = adminRoleID }
               );


           //Seeding Products
           builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Epilator", Description = "A small tool for removing unwanted hair in unwanted places", Category = CategoryType.Electronics, Price = 30 },
                new Product { Id = 2, Name = "Headphones", Description = "For IPhone X", Category = CategoryType.Electronics, Price = 5 },
                new Product { Id = 3, Name = "Exploding Kittens", Description = "A board game", Category = CategoryType.Other, Price = 20 },
                new Product { Id = 4, Name = "Martini", Description = "A cool drink delivered to your door", Category = CategoryType.Drinks, Price = 10 },
                new Product { Id = 5, Name = "Hamburger", Description = "Meat, Salads, Fries", Category = CategoryType.Food, Price = 5 },
                new Product { Id = 6, Name = "Enterprise Integration Patterns", Description = "by Gregor Hohpe and Bobby Woolf", Category = CategoryType.Books, Price = 50 }
            );
        }
    }
}
