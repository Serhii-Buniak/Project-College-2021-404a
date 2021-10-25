using System.Linq;

namespace MyProject.Models.Entities
{
    public class EFAccessoryRepository : IAccessoryRepository
    {

        private readonly StoreDbContext context;
        public EFAccessoryRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Accessory> Items => context.Accessories;
    }
}
