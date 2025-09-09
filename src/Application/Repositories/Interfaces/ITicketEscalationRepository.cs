using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ITicketEscalationRepository : IGenericRepository<TicketEscalation>
    {
        Task<IEnumerable<TicketEscalation>> GetByTicketIdAsync(Guid ticketId);
       
        Task<TicketEscalation> GetLatestEscalationByTicketIdAsync(Guid ticketId);
    }
}
