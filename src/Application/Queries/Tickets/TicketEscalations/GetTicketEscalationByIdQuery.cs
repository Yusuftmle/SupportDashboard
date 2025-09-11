using Application.DTOs.Ticket.TicketEscalation;
using MediatR;

namespace Application.Queries.Tickets.TicketEscalations
{
    public class GetTicketEscalationByIdQuery : IRequest<TicketEscalationDto?>
    {
        public Guid Id { get; set; }
    }
}
