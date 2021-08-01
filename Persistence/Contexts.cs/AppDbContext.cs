using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Category>()
                .ToTable("Categories");
            
            modelBuilder
                .Entity<Category>()
                .HasKey(property => property.Id);
            
            modelBuilder
                .Entity<Category>()
                .Property(property => property.Id).IsRequired().ValueGeneratedOnAdd();
            
            modelBuilder
                .Entity<Category>()
                .Property(property => property.Name)
                .IsRequired()
                .HasMaxLength(30);
            
            modelBuilder
                .Entity<Category>()
                .HasMany(property => property.Products)
                .WithOne(property => property.Category);

            modelBuilder
                .Entity<Category>()
                .HasData("Product");
        }
    }
}