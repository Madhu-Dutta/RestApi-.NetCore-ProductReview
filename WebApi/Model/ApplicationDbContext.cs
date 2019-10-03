using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

    namespace WebApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasKey(t => new
            {
                t.ProductId,
                t.CategoryId
            });
            modelBuilder.Entity<CategoryProduct>()
                
            .HasOne(x => x.Category)
            .WithMany(y => y.ProductCategory)
            .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<CategoryProduct>()
              .HasOne(x => x.Product)
              .WithMany(y => y.ProductCategory)
              .HasForeignKey(x => x.ProductId);

            
        }

        public DbSet<Review> Review { get; set; }

        public DbSet<WebApi.Model.CategoryProduct> CategoryProduct { get; set; }

        public DbSet<CategoryProduct> ProductCategory { get; set; }
    }
}
