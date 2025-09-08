using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = true;
        public Guid? ManagerId { get; private set; }

        // Navigation
        public User? Manager { get; private set; }
        public ICollection<User> Users { get; private set; } = new List<User>();
        public ICollection<TicketCategory> Categories { get; private set; } = new List<TicketCategory>();
    }
}
