using System;
using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFSubcategoryRepository : ISubcategoryRepository
    {
        private readonly StoreDbContext _context;

        public EFSubcategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Subcategory> Subcategories => _context.Subcategories;

        public void Add(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
        }

        public Subcategory FindByIdAsync(Guid id)
        {
            return _context.Subcategories.Find(id);
        }
    }

}
