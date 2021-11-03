using Microsoft.EntityFrameworkCore;
using ZooStore.Models;

namespace ZooStore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
           : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
