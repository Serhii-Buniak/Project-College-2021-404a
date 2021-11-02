using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Entities
{
    public interface IReadOnlyProductRepository<T>
    {
        IQueryable<T> Items { get; }
    }
    public interface IFoodRepository : IReadOnlyProductRepository<Food>
    {
        
    }
    public interface IAnimalRepository : IReadOnlyProductRepository<Animal>
    {

    }
    public interface IAccessoryRepository : IReadOnlyProductRepository<Accessory>
    {

    }
}
