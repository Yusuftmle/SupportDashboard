using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Persistence.Repositories
{
    
     public class AIPromptTemplateRepository : GenericRepository<AIPromptTemplate>, IAIPromptTemplateRepository
    {
        public AIPromptTemplateRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<AIPromptTemplate>())
        {
        }
    }
}
