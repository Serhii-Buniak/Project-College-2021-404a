using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Food> Foods { get; }
        IQueryable<Animal> Animals { get; }
        IQueryable<Accessory> Accessories { get; }
    }
}
