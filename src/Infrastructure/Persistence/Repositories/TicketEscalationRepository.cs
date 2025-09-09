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
    public class TicketEscalationRepository : GenericRepository<TicketEscalation>, ITicketEscalationRepository
    {

        public TicketEscalationRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<TicketEscalation>())
        {
        }

        public async Task<IEnumerable<TicketEscalation>> GetByTicketIdAsync(Guid ticketId)
        {
            return await GetList(t => t.TicketId == ticketId,
                orderBy: q => q.OrderBy(t => t.EscalatedDate));
        }

       

        public async Task<TicketEscalation> GetLatestEscalationByTicketIdAsync(Guid ticketId)
        {
            var escalations = await GetList(t => t.TicketId == ticketId,
                orderBy: q => q.OrderByDescending(t => t.EscalatedDate));
            return escalations.FirstOrDefault();
        }
    }
   


}
