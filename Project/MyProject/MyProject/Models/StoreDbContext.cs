using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
           : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
    }
}
