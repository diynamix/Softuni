namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    
    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<CategoryProduct> CategoriesProducts { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasMany(u => u.ProductsBought)
                    .WithOne(p => p.Buyer)
                    .HasForeignKey(p => p.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasMany(u => u.ProductsSold)
                    .WithOne(p => p.Seller)
                    .HasForeignKey(p => p.SellerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
