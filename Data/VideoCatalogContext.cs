using VideoCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace VideoCatalog.Data
{
    public class VideoCatalogContext : DbContext
    {
        public DbSet<Catalog> Catalogs { set; get; }
        public DbSet<Category> Categories { set; get; }

        public DbSet<Item> Items { set; get; }

        public VideoCatalogContext(DbContextOptions<VideoCatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().ToTable("Catalog");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Item>().ToTable("Item");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=CatalogUniversity;User Id =SA; Password=DungMy@#96;MultipleActiveResultSets=true");
        }
    }
}