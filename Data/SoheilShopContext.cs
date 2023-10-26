using Microsoft.EntityFrameworkCore;
using SoheilShop.Models;

namespace SoheilShop.Data
{
    public class SoheilShopContext : DbContext
    {
        public SoheilShopContext(DbContextOptions<SoheilShopContext> options) : base(options) { }

        public DbSet<Category> category { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductId, t.CategoryId });

            //modelBuilder.Entity<Product>
            //    (p =>
            //    {
            //        p.HasKey(w => w.Id);
            //        p.OwnsOne<Item>(w => w.Item);
            //        p.HasOne<Item>(w => w.Item).WithOne(w => w.Product)
            //        .HasForeignKey<Item>(w => w.Id);
            //    });
            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(W => W.Id);
            });
            #region seed Data
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                Id = 1,
                Name = "Soheil",
                Description = "Description1"
            }, new Category()
            {
                Id = 2,
                Name = "لباس ورزشی ",
                Description = "گروه لباس ورزشی"
            }, new Category()
            {
                Id = 3,
                Name = "ساعت مچی",
                Description = "ساعت مچی"
            }, new Category()
            {
                Id = 4,
                Name = "لوازم خانگی",
                Description = "لوازم خانگی"
            });
            #endregion

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Price = 1382.0M,
                    QuantityInStock = 5
                },
                new Item
                {
                    Id = 2,
                    Price = 85.5M,
                    QuantityInStock = 55
                },
                new Item
                {
                    Id = 3,
                    Price = 89.0M,
                    QuantityInStock = 4
                },
                new Item
                {
                    Id = 4,
                    Price = 234.0M,
                    QuantityInStock = 33
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ItemId = 1,
                    Name = "product1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"
                },
                new Product
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "product2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"
                },
                new Product
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "product3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"
                },
                new Product
                {
                    Id = 4,
                    ItemId = 4,
                    Name = "product4",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"
                }
                );

            modelBuilder.Entity<CategoryToProduct>().HasData(
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 1 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 2 },  
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 1, ProductId = 4 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 4 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 4 },
                new CategoryToProduct() { CategoryId = 4, ProductId = 4 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
