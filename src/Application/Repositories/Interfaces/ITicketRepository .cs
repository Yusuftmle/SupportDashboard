using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetByStatusAsync(TicketStatus status);
        Task<IEnumerable<Ticket>> GetByCustomerIdAsync(Guid customerId);
        Task<IEnumerable<Ticket>> GetByAssignedUserIdAsync(Guid userId);
        Task<IEnumerable<Ticket>> GetOverdueSLATicketsAsync();
        Task<IEnumerable<Ticket>> GetByPriorityAsync(PriorityStatus priority);
        Task<int> GetTicketCountByStatusAsync(TicketStatus status);
    }
}
