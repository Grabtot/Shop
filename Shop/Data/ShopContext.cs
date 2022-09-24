using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersCart> Cart { get; private set; }
        public DbSet<History> History { get; private set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }


    }
}
