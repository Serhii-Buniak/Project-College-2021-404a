using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFProductRepository : IProductRepository<Product>
    {

        private readonly StoreDbContext context;
        public EFProductRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Items => context.Products;
    }
}
