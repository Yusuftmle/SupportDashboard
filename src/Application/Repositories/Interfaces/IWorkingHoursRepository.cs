using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface IWorkingHoursRepository : IGenericRepository<WorkingHours>
    {
        Task<IEnumerable<WorkingHours>> GetByDepartmentIdAsync(Guid departmentId);
        Task<WorkingHours> GetCurrentWorkingHoursAsync();
        Task<bool> IsWorkingHoursAsync(DateTime dateTime);
    }
}
