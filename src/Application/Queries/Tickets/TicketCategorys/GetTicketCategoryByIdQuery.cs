using Application.DTOs.Ticket.TicketCategory;
using MediatR;

namespace Application.Queries.TicketCategorys
{
    public class GetTicketCategoryByIdQuery : IRequest<TicketCategoryDto?>
    {
        public Guid Id { get; set; }
    }
}
