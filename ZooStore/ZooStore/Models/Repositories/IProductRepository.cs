using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooStore.Models.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        IQueryable<T> Items { get; }
    }

    public interface IProductRepository : IReadOnlyRepository<Product>
    {
        void Add(Product product);
    }

    public interface ICategoryRepository : IReadOnlyRepository<Category>
    {
        void Add(Category category);
    }

    public interface ISubcategoryRepository : IReadOnlyRepository<Subcategory>
    {
        void Add(Subcategory subcategory);
    }
}
