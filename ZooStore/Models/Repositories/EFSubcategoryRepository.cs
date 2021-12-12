using System;
using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFSubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFSubcategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Subcategory> Subcategories => _context.Subcategories;

        public void Add(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
        }

        public Subcategory FindByIdAsync(long id)
        {
            return _context.Subcategories.Find(id);
        }
    }

}
