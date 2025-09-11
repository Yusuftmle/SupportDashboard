using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket.TicketComment;
using MediatR;

namespace Application.RequestModels.Ticket.TicketComment
{
    public class CreateTicketCommentCommand : IRequest<Guid>
    {
        public CreateTicketCommentDto Comment { get; set; }
    }
}
