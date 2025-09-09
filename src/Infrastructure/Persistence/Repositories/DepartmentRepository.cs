using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<Department>())
        {
        }

        public async Task<IEnumerable<Department>> GetActiveDepartmentsAsync()
        {
            return await GetList(d => d.IsActive);
        }

        public async Task<Department> GetByNameAsync(string name)
        {
            return await FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
