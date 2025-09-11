using Application.DTOs.Ticket.TicketComment;
using MediatR;

namespace Application.Queries.TicketComments
{
    public class GetAll : IRequest<List<TicketCommentDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
