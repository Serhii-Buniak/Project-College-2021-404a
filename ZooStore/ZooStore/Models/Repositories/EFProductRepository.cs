using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public EFProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Items => _context.Products;

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }

    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;

        public EFCategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> Items => _context.Categories;

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }

    public class EFSubcategoryRepository : ISubcategoryRepository
    {
        private readonly StoreDbContext _context;

        public EFSubcategoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Subcategory> Items => _context.Subcategories;

        public void Add(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            _context.SaveChanges();
        }
    }

}
