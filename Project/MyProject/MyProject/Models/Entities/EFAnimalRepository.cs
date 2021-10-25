using System.Linq;

namespace MyProject.Models.Entities
{
    public class EFAnimalRepository : IAnimalRepository
    {

        private readonly StoreDbContext context;
        public EFAnimalRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Animal> Items => context.Animals;
    }
}
