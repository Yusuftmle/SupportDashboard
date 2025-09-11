using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.Ticket.TicketAttachment
{
    public class DeleteTicketAttachmentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

}
