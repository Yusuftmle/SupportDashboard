using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketEscalation
{
    public class CreateTicketEscalationDto
    {
        public Guid TicketId { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
