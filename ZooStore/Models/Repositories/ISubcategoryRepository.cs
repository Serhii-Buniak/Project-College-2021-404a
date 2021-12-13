using System.Linq;

namespace ZooStore.Models.Repositories
{
    public interface ISubcategoryRepository
    {
        IQueryable<Subcategory> Subcategories { get; }
        Subcategory FindByIdAsync(long id);
        void Add(Subcategory subcategory);
    }
}
