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
        private readonly ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;


        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public async Task<Product> FindByIdAsync(long id)
        {
            return await _context.Products.FindAsync(id);
        }
    }

}
