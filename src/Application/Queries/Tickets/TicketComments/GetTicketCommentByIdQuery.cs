using Application.DTOs.Ticket.TicketComment;
using MediatR;

namespace Application.Queries.Tickets.TicketComments
{
    public class GetTicketCommentByIdQuery : IRequest<TicketCommentDto?>
    {
        public Guid Id { get; set; }
    }
}
