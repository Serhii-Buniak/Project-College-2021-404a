using System.Linq;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFProductHistoryRepository : IProductHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFProductHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<ProductHistory> ProductHistory => _context.ProductHistory;

        public async Task AddAsync(ProductHistory product)
        {
            await _context.ProductHistory.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
