using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.ConversationHistory
{
    public class DeleteConversationHistoryCommand : IRequest<bool>
    {
        public Guid SessionId { get; set; }
    }
}
