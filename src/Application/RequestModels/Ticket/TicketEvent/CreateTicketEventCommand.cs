using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket.TicketEvent;
using MediatR;

namespace Application.RequestModels.Ticket.TicketEvent
{
    public class CreateTicketEventCommand : IRequest<Guid>
    {
        public CreateTicketEventDto Event { get; set; }
    }

}
