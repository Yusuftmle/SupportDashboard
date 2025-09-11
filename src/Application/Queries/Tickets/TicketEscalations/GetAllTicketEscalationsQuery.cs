using MediatR;

namespace Application.Queries.TicketEscalations
{
    public class GetAll : IRequest<List<TicketEscalationDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
