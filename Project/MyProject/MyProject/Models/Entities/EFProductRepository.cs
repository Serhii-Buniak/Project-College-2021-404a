using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Entities
{
    public class EFProductRepository : IReadOnlyRepository<Product>
    {

        private readonly StoreDbContext context;
        public EFProductRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Items => context.Products;
    }
}
