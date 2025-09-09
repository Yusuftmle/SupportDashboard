using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class SLARepository : GenericRepository<SLA>, ISLAARepository
    {
        public SLARepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<SLA>())
        {
        }

        public async Task<IEnumerable<SLA>> GetActiveSLAsAsync()
        {
            return await GetList(s => s.IsActive);
        }

        public async Task<SLA> GetByPriorityAsync(PriorityStatus priority)
        {
            return await FirstOrDefaultAsync(s => s.Priority == priority && s.IsActive);
        }
    }
}
