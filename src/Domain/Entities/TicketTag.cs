using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketTag : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Color { get; private set; } = "#007bff";
        public bool IsActive { get; private set; } = true;

        // Navigation - Many-to-many
        public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    }
}
