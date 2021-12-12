using System;
using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> Categories => _context.Categories;

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public Category FindByIdAsync(long id)
        {
            return _context.Categories.Find(id);
        }
    }

}
