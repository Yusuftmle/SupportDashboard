using Application.DTOs.Ticket.TicketCategory;
using MediatR;

namespace Application.Queries.TicketCategorys
{
    public class GetAll : IRequest<List<TicketCategoryDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
