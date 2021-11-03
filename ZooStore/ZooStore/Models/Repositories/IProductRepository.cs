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
    public interface IProductRepository<T> : IReadOnlyRepository<T> where T : Product
    {
        void Add(T product);
    }

}
