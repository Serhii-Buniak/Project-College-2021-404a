using System;
using System.Linq;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public EFCategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> Categories => _context.Categories;

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        //TODO: IT
        //public async Category FindByIdAsync(Guid id)
        //{
        //    return await _context.
        //}
    }

}
