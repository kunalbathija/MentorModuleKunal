using Microsoft.EntityFrameworkCore;

namespace Common
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                id = 1,
                name = "Product1",
                availability = 1,
                description = "Product 1 description"
            }, new ProductModel
            {
                id = 2,
                name = "Product2",
                availability = 4,
                description = "Product 2 description"
            }, new ProductModel
            {
                id = 3,
                name = "Product3",
                availability = 6,
                description = "Product 3 description"
            }, new ProductModel
            {
                id = 4,
                name = "Product4",
                availability = 32,
                description = "Product 4 description"
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
