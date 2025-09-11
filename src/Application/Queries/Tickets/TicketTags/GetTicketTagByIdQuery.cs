using MediatR;

namespace Application.Queries.TicketTags
{
    public class GetTicketTagByIdQuery : IRequest<TicketTagDto?>
    {
        public Guid Id { get; set; }
    }
}
