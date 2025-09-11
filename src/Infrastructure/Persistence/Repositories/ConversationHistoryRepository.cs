using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class ConversationHistoryRepository: GenericRepository<ConversationHistory>, IConversationHistoryRepository
    {

        public ConversationHistoryRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<ConversationHistory>())
        {
        }
    }
}
