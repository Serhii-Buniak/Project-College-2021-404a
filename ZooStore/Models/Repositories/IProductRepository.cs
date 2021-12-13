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
        Task<Product> FindByIdAsync(long id);
        void Add(Product product);
    }
}
