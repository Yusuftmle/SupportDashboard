using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketComment
{
    public class CreateTicketCommentDto
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsInternal { get; set; } = false;
        public bool IsPublic { get; set; } = true;
    }
}
