using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Entities
{
    public interface IReadOnlyRepository<T>
    {
        IQueryable<T> Items { get; }
    }
    public interface IFoodRepository : IReadOnlyRepository<Food>
    {
        
    }
    public interface IAnimalRepository : IReadOnlyRepository<Animal>
    {

    }
    public interface IAccessoryRepository : IReadOnlyRepository<Accessory>
    {

    }
}
