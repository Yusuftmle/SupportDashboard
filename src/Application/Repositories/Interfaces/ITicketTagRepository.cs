using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ITicketTagRepository : IGenericRepository<TicketTag>
    {
        Task<IEnumerable<TicketTag>> GetByTicketIdAsync(Guid ticketId);
        Task<IEnumerable<TicketTag>> GetPopularTagsAsync(int limit = 10);
        Task<bool> TagExistsAsync(string tagName);
    }
}
