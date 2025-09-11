using Application.DTOs.Ticket.TicketEscalation;
using MediatR;

namespace Application.Queries.Tickets.TicketEscalations
{
    public class GetAll : IRequest<List<TicketEscalationDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
