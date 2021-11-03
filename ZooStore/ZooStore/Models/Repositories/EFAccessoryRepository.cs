using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFAccessoryRepository : IProductRepository<Accessory>
    {

        private readonly StoreDbContext _context;
        public EFAccessoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Accessory> Items => _context.Accessories;

        public void Add(Accessory product)
        {
            _context.Accessories.Add(product);
            _context.SaveChanges();
        }
    }
}
