// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ManageApi.Models;

namespace ManageApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Manage> Manages { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Ensure Id is generated on add (auto-increment)

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Manage)
                .WithMany()
                .HasForeignKey(p => p.ManageId)
                .IsRequired(false); // Optional relationship

            // If you have other configurations for Product entity, add them here
        }

        private void ConfigureLogging(DbContextOptionsBuilder optionsBuilder = null)
        {
            // Configure logging to log SQL statements
            if (optionsBuilder == null)
                optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                          .EnableSensitiveDataLogging(); // Optional: Enable sensitive data logging

            // You can also log to other providers like Debug, etc.
            // builder.AddDebug();
            // builder.AddEventLog();
        }
    }
}
