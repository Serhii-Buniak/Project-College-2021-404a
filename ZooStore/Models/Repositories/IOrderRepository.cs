using System.Linq;

namespace ZooStore.Models.Repositories
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        IQueryable<Order> Orders { get; }
    }
}
