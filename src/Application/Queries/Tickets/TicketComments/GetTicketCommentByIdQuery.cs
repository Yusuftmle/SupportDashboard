using MediatR;

namespace Application.Queries.TicketComments
{
    public class GetTicketCommentByIdQuery : IRequest<TicketCommentDto?>
    {
        public Guid Id { get; set; }
    }
}
