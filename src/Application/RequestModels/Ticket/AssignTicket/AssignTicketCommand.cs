using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.Ticket.AssignTicket
{
    public class AssignTicketCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid AgentId { get; set; }
    }
}
