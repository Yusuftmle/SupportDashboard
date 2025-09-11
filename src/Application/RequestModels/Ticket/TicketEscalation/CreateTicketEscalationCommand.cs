using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket.TicketEscalation;
using MediatR;

namespace Application.RequestModels.Ticket.TicketEscalation
{
    public class CreateTicketEscalationCommand : IRequest<Guid>
    {
        public CreateTicketEscalationDto Escalation { get; set; }
    }
}
