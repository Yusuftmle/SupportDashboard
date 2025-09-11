using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketEscalation
{
    public class TicketEscalationDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime EscalatedDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public string TicketTitle { get; set; } = string.Empty; // Navigation
        public string FromUserName { get; set; } = string.Empty; // Navigation
        public string ToUserName { get; set; } = string.Empty; // Navigation
    }
}
