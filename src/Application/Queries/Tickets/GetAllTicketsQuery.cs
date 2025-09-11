using MediatR;

namespace Application.Queries.Tickets
{
    public class GetAll : IRequest<List<TicketDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
