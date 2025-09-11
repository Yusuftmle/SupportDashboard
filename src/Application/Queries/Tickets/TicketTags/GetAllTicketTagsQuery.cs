using MediatR;

namespace Application.Queries.TicketTags
{
    public class GetAll : IRequest<List<TicketTagDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
