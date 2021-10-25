using System.Linq;

namespace MyProject.Models.Entities
{
    public class EFFoodRepository : IFoodRepository
    {

        private readonly StoreDbContext context;
        public EFFoodRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Food> Items => context.Foods;
    }
}
