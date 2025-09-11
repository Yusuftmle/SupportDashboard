using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket.TicketAttachment;
using MediatR;

namespace Application.RequestModels.Ticket.TicketAttachment
{
    public class CreateTicketAttachmentCommand : IRequest<Guid>
    {
        public CreateTicketAttachmentDto Attachment { get; set; }
    }
}
