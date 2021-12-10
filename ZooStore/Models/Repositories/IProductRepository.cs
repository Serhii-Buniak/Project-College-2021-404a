using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooStore.Models.Repositories
{
    public interface IProductRepository 
    {
        IQueryable<Product> Products { get; }
        Product FindByIdAsync(Guid id);
        void Add(Product product);
    }

    public interface ICategoryRepository 
    {
        IQueryable<Category> Categories { get; }
        Category FindByIdAsync(Guid id);
        void Add(Category category);
    }

    public interface ISubcategoryRepository 
    {
        IQueryable<Subcategory> Subcategories { get; }
        Subcategory FindByIdAsync(Guid id);
        void Add(Subcategory subcategory);
    }
}
