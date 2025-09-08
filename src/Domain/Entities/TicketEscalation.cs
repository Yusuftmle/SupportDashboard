using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class TicketEscalation : BaseEntity
    {
        public Guid TicketId { get; private set; }
        public Guid FromUserId { get; private set; }
        public Guid ToUserId { get; private set; }
        public string Reason { get; private set; } = string.Empty;
        public DateTime EscalatedDate { get; private set; }
        public EscalationType Type { get; private set; }

        // Navigation
        public Ticket Ticket { get; private set; }
        public User FromUser { get; private set; }
        public User ToUser { get; private set; }
    }
}
