using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class SLA:BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public PriorityStatus Priority { get; private set; }
        public int ResponseTimeHours { get; private set; }
        public int ResolutionTimeHours { get; private set; }
        public bool IsActive { get; private set; } = true;

        // Navigation
        public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    }
}
