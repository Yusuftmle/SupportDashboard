using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class TicketEvent:BaseEntity
    {
        public Guid TicketId { get; private set; }
        public TicketEventType EventType { get; private set; }
        public string? EventData { get; private set; }
        public Guid? UserId { get; private set; }
        public string? OldValue { get; private set; }
        public string? NewValue { get; private set; }
        public string? Comment { get; private set; }

        // Navigation properties
        public Ticket Ticket { get; private set; } = null!;
        public User? User { get; private set; }

        // Parameterless constructor for EF Core
        private TicketEvent() { }

        // Public constructor for creating new instances
        public TicketEvent(Guid ticketId, TicketEventType eventType, string? eventData = null)
        {
            TicketId = ticketId;
            EventType = eventType;
            EventData = eventData;
        }

        // Method to set user who performed the action
        public void SetUser(Guid? userId)
        {
            UserId = userId;
        }

        // Method to set old and new values for status changes
        public void SetValueChange(string? oldValue, string? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        // Method to add comment
        public void SetComment(string? comment)
        {
            Comment = comment;
        }
    }
}
