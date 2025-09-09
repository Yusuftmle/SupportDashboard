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
    public class TicketTagRepository : GenericRepository<TicketTag>, ITicketTagRepository
    {
        public TicketTagRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<TicketTag>())
        {
        }

        public async Task<IEnumerable<TicketTag>> GetByTicketIdAsync(Guid ticketId)
        {
            return await GetList(t => t.Id == ticketId);
        }

        public async Task<IEnumerable<TicketTag>> GetPopularTagsAsync(int limit = 10)
        {
            var allTags = await GetAll();
            return allTags.GroupBy(t => t.Name)
                         .OrderByDescending(g => g.Count())
                         .Take(limit)
                         .Select(g => g.First())
                         .ToList();
        }

        public async Task<bool> TagExistsAsync(string tagName)
        {
            return await AnyAsync(t => t.Name == tagName);
        }
    }

}
