using MediatR;

namespace Application.Queries.Tickets
{
    public class GetTicketByIdQuery : IRequest<TicketDto?>
    {
        public Guid Id { get; set; }
    }
}
