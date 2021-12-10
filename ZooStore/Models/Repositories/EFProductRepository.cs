using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public EFProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Items => _context.Products;

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }

}
