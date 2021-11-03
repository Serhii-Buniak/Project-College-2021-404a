using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFAnimalRepository : IProductRepository<Animal>
    {

        private readonly StoreDbContext _context;
        public EFAnimalRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Animal> Items => _context.Animals;

        public void Add(Animal product)
        {
            _context.Animals.Add(product);
            _context.SaveChanges();
        }
    }
}
