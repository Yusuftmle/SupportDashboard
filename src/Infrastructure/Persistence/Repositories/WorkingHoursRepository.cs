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
    public class WorkingHoursRepository : GenericRepository<WorkingHours>, IWorkingHoursRepository
    {
        public WorkingHoursRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<WorkingHours>())
        {
        }

        public async Task<IEnumerable<WorkingHours>> GetByDepartmentIdAsync(Guid departmentId)
        {
            return await GetList(w => w.DepartmentId == departmentId);
        }

        public async Task<WorkingHours> GetCurrentWorkingHoursAsync()
        {
            var currentDay = DateTime.Now.DayOfWeek;
            return await FirstOrDefaultAsync(w => w.DayOfWeek == currentDay);
        }

        public async Task<bool> IsWorkingHoursAsync(DateTime dateTime)
        {
            var dayOfWeek = dateTime.DayOfWeek;
            var timeOfDay = dateTime.TimeOfDay;

            var workingHours = await FirstOrDefaultAsync(w => w.DayOfWeek == dayOfWeek);

            if (workingHours == null) return false;

            return timeOfDay >= workingHours.StartTime && timeOfDay <= workingHours.EndTime;
        }
    }
}
