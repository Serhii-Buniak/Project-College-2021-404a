using System;
using System.Linq;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    class EFDepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EFDepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Department> Departments => _context.Departments;
        public void Add(Department address)
        {
            _context.Departments.Add(address);
            _context.SaveChanges();
        }

        public async Task<Department> FindByIdAsync(long id)
        {
            return await _context.Departments.FindAsync(id);
        }
    }
}
