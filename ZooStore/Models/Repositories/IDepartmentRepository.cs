using System.Linq;
using System.Threading.Tasks;

namespace ZooStore.Models.Repositories
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> Departments { get; }
        Task<Department> FindByIdAsync(long id);
        void Add(Department address);
    }
}
