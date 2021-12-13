using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Repositories
{
    public interface IProductHistoryRepository
    {
        Task AddAsync(ProductHistory product);
        IQueryable<ProductHistory> ProductHistory { get; }
    }
}
