using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Task<Product> FindByIdAsync(long id);
        void Add(Product product);
    }

    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        Category FindByIdAsync(long id);
        void Add(Category category);
    }

    public interface ISubcategoryRepository
    {
        IQueryable<Subcategory> Subcategories { get; }
        Subcategory FindByIdAsync(long id);
        void Add(Subcategory subcategory);
    }

    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }
        Task<Department> FindByIdAsync(long id);
        void Add(Department address);
    }
    public interface IOrderRepository
    {
        public void Add(Order order);
        IQueryable<Order> Orders { get; }
    }

    public interface ICartRepository
    {
        public void Add(Product product, AppUser user);
        public void Remove(Product product, AppUser user);
        public bool Contains(Product product, AppUser user);
    }
    public interface ISearchHistoryRepository
    {
        Task AddAsync(SearchHistory searchHistory);
        IQueryable<SearchHistory> SearchHistory { get; }
    }

    public interface IProductHistoryRepository
    {
        Task AddAsync(ProductHistory product);
        IQueryable<ProductHistory> ProductHistory { get; }
    }
    public class EFProductHistoryRepository : IProductHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFProductHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<ProductHistory> ProductHistory => _context.ProductHistory;

        public async Task AddAsync(ProductHistory product)
        {
            await _context.ProductHistory.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
