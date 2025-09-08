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
        public Guid? UserId { get; private set; } // Olayı gerçekleştiren kullanıcı
        public string? OldValue { get; private set; } // Önceki değer (status değişimi için)
        public string? NewValue { get; private set; } // Yeni değer
        public string? Comment { get; private set; } // Kullanıcı yorumu
        public Guid TicketId { get; private set; }
        public TicketEventType EventType { get; private set; }
        public string? EventData { get; private set; } // JSON gibi opsiyonel ek veri

        public User? User { get; private set; }
        // Navigation
        public Ticket? Ticket { get; private set; }


        public TicketEvent(Guid ticketId, TicketEventType eventType, string? eventData = null)
        {
            TicketId = ticketId;
            EventType = eventType;
            EventData = eventData;
        }
    }
}
