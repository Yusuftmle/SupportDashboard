using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TicketAttachmentRepository : GenericRepository<TicketAttachment>, ITicketAttachmentRepository
    {
        public TicketAttachmentRepository(DbContext dbContext) : base(dbContext, dbContext.Set<TicketAttachment>())
        {
        }

        public async Task<IEnumerable<TicketAttachment>> GetByTicketIdAsync(Guid ticketId)
        {
            return await GetList(t => t.TicketId == ticketId);
        }

        public async Task<long> GetTotalAttachmentSizeByTicketIdAsync(Guid ticketId)
        {
            var attachments = await GetList(t => t.TicketId == ticketId);
            return attachments.Sum(t => t.FileSize);
        }
    }
}
