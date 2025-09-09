using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ITicketCategoryRepository : IGenericRepository<TicketCategory>
    {
        Task<IEnumerable<TicketCategory>> GetActiveCategoriesAsync();
        Task<TicketCategory> GetByNameAsync(string name);
    }
}
