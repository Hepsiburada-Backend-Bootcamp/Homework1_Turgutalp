using Homework1.Core.Entity;
using Homework1.Data.Configurations;
using Homework1.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Data
{
    public class HomeworkDbContext : DbContext
    {
        public HomeworkDbContext(DbContextOptions<HomeworkDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}