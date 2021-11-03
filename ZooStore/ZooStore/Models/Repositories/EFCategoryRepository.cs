using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public EFCategoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Category> Items => _context.Categories;
    }
}
