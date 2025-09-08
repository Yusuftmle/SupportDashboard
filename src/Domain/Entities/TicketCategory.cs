using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketCategory
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public Guid? DepartmentId { get; private set; }
        public bool IsActive { get; private set; } = true;
        public int EstimatedResolutionHours { get; private set; } = 24;

        // Navigation
        public Department? Department { get; private set; }
        public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    }
}
