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
    public class TicketCategoryRepository : GenericRepository<TicketCategory>, ITicketCategoryRepository
    {
        public TicketCategoryRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<TicketCategory>())
        {
        }

        public async Task<IEnumerable<TicketCategory>> GetActiveCategoriesAsync()
        {
            return await GetList(t => t.IsActive);
        }

        public async Task<TicketCategory> GetByNameAsync(string name)
        {
            return await FirstOrDefaultAsync(t => t.Name == name);
        }
    }
}
