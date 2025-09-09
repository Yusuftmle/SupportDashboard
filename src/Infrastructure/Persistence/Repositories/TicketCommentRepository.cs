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
    public class TicketCommentRepository : GenericRepository<TicketComment>, ITicketCommentRepository
    {
        public TicketCommentRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<TicketComment>())
        {
        }

        public async Task<IEnumerable<TicketComment>> GetByTicketIdAsync(Guid ticketId)
        {
            return await GetList(t => t.TicketId == ticketId,
                orderBy: q => q.OrderBy(t => t.CreateDate));
        }

        public async Task<IEnumerable<TicketComment>> GetPublicCommentsByTicketIdAsync(Guid ticketId)
        {
            return await GetList(t => t.TicketId == ticketId && t.IsPublic,
                orderBy: q => q.OrderBy(t => t.CreateDate));
        }

        public async Task<TicketComment> GetLatestCommentByTicketIdAsync(Guid ticketId)
        {
            var comments = await GetList(t => t.TicketId == ticketId,
                orderBy: q => q.OrderByDescending(t => t.CreateDate));
            return comments.FirstOrDefault();
        }
    }
}
