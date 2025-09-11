using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ConversationHistory;
using MediatR;

namespace Application.RequestModels.ConversationHistory
{
    public class CreateConversationHistoryCommand : IRequest<Guid>
    {
        public CreateConversationHistoryDto History { get; set; }
    }

}
