using Microsoft.EntityFrameworkCore;
using Supermarket.API_new.Domain.Models;

namespace Supermarket.API_new.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Category>()
                .ToTable("Categories");

            builder
                .Entity<Category>()
                .HasKey(property => property.Id);

            builder
                .Entity<Category>()
                .Property(property => property.Id).IsRequired().ValueGeneratedOnAdd();

            builder
                .Entity<Category>()
                .Property(property => property.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Entity<Category>()
                .HasMany(property => property.Products)
                .WithOne(property => property.Category)
                .HasForeignKey(property => property.CategoryId);

            builder
                .Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 100,
                        Name = "Fruits and Vegetables"
                    },
                    new Category
                    {
                        Id = 101,
                        Name = "Dairy",
                    }
                );

            // crea tabella
            // crea id key
            // per la proprietà id -> required & generata on add  
            // per la proprietà NAME -> required & max lenght is 50  
            // per la proprietà qty in package -> required
            // per la proprietà unity of measure -> required  

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}