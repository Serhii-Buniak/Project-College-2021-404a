using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Repositories
{
    public interface ISearchHistoryRepository
    {
        Task AddAsync(SearchHistory searchHistory);
        IQueryable<SearchHistory> SearchHistory { get; }
    }
}
