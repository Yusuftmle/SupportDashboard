using MediatR;

namespace Application.Queries.Tickets.TicketTags
{
    public class GetTicketTagByIdQuery : IRequest<TicketTagDto?>
    {
        public Guid Id { get; set; }
    }
}
