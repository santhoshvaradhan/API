using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        protected ProductDbContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<User>().HasData(
                  new User { Id = 1, UserName = "test1", Password = "test1@123", Role = "SuperAdmin" },
                  new User { Id = 2, UserName = "test2", Password = "test2@123", Role = "Admin" },
                  new User { Id = 3, UserName = "test3", Password = "test3@123", Role = "User" }
              );

            

          
        }


    }
}
