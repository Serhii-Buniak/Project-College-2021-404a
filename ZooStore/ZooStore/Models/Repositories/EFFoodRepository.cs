using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFFoodRepository : IProductRepository<Food>
    {

        private readonly StoreDbContext _context;
        public EFFoodRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Food> Items => _context.Foods;

        public void Add(Food product)
        {
            _context.Foods.Add(product);
            _context.SaveChanges();
        }
    }
}
