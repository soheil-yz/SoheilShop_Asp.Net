using Microsoft.EntityFrameworkCore;
using SoheilShop.Models;

namespace SoheilShop.Data
{
    public class SoheilShopContext : DbContext
    {
        public SoheilShopContext(DbContextOptions<SoheilShopContext> options) : base(options) { }

        public DbSet<Category> category { get; set; }
    }
}
