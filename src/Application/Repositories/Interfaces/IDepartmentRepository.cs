using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> GetActiveDepartmentsAsync();
        Task<Department> GetByNameAsync(string name);
    }
}
