using MediatR;

namespace Application.Queries.TicketEscalations
{
    public class GetTicketEscalationByIdQuery : IRequest<TicketEscalationDto?>
    {
        public Guid Id { get; set; }
    }
}
