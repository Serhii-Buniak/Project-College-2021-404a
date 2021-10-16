using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class EFProductRepository : IProductRepository
    {

        private readonly StoreDbContext context;
        public EFProductRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public IQueryable<Food> Foods => throw new NotImplementedException();

        public IQueryable<Animal> Animals => throw new NotImplementedException();

        public IQueryable<Accessory> Accessories => throw new NotImplementedException();
    }
}
