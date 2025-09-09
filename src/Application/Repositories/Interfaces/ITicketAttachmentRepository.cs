using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ITicketAttachmentRepository : IGenericRepository<TicketAttachment>
    {
        Task<IEnumerable<TicketAttachment>> GetByTicketIdAsync(Guid ticketId);
        Task<long> GetTotalAttachmentSizeByTicketIdAsync(Guid ticketId);
    }
}
