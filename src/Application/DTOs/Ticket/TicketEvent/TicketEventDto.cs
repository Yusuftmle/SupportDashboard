using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketEvent
{
    public class TicketEventDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string? EventData { get; set; }
        public Guid? UserId { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UserFullName { get; set; } // Navigation
        public string TicketTitle { get; set; } = string.Empty; // Navigation
    }
}
