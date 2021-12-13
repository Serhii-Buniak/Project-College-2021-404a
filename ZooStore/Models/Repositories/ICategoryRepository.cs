using System.Linq;

namespace ZooStore.Models.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        Category FindByIdAsync(long id);
        void Add(Category category);
    }
}
