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
    public class AIExecutionLogRepository : GenericRepository<AIExecutionLog>, IAIExecutionLogRepository
    {
        public AIExecutionLogRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<AIExecutionLog>())
        {
        }
    }
}
