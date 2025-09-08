using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketComment:BaseEntity
    {
        public Guid TicketId { get; private set; }
        public Guid UserId { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public bool IsInternal { get; private set; } // Sadece ajanlar görebilir
        public bool IsPublic { get; private set; } = true;

        // Navigation
        public Ticket Ticket { get; private set; }
        public User User { get; private set; }
    }
}
