using Application.DTOs.Ticket.TicketAttachment;
using MediatR;

namespace Application.Queries.TicketAttachments
{
    public class GetTicketAttachmentByIdQuery : IRequest<TicketAttachmentDto?>
    {
        public Guid Id { get; set; }
    }
}
