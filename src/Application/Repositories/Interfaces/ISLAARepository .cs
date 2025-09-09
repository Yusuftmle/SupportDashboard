using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface ISLAARepository : IGenericRepository<SLA>
    {
        Task<IEnumerable<SLA>> GetActiveSLAsAsync();
        Task<SLA> GetByPriorityAsync(PriorityStatus priority);
    }
   
}
