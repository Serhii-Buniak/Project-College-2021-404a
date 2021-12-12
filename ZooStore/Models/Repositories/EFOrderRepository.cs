using System;
using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Orders => _context.Orders;

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
