using Application.DTOs.Ticket.TicketAttachment;
using MediatR;

namespace Application.Queries.TicketAttachments
{
    public class GetAll : IRequest<List<TicketAttachmentDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
