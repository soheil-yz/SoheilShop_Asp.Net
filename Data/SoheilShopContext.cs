using Microsoft.EntityFrameworkCore;
using SoheilShop.Models;

namespace SoheilShop.Data
{
    public class SoheilShopContext : DbContext
    {
        public SoheilShopContext(DbContextOptions<SoheilShopContext> options) : base(options) { }

        public DbSet<Category> category { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
