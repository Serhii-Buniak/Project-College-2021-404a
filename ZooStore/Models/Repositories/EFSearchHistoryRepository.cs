using System.Linq;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFSearchHistoryRepository : ISearchHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFSearchHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<SearchHistory> SearchHistory => _context.SearchHistory;

        public async Task AddAsync(SearchHistory searchHistory)
        {
            await _context.SearchHistory.AddAsync(searchHistory);
            await _context.SaveChangesAsync();
        }
    }
}
