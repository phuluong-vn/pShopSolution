using Microsoft.EntityFrameworkCore;
using pShopSolution.Data.Entities;

namespace pShopSolution.Data.EF
{
    public class PShopDbContext : DbContext
    {
        public PShopDbContext(DbContextOptions<PShopDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products;
        public DbSet<Category> Categories;
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}