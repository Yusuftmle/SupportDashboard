using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ITicketCommentRepository : IGenericRepository<TicketComment>
    {
        Task<IEnumerable<TicketComment>> GetByTicketIdAsync(Guid ticketId);
        Task<IEnumerable<TicketComment>> GetPublicCommentsByTicketIdAsync(Guid ticketId);
        Task<TicketComment> GetLatestCommentByTicketIdAsync(Guid ticketId);
    }
}
