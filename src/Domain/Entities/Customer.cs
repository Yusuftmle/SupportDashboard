using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CompanyName { get; private set; } = string.Empty;
        public string ContactPerson { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string? PhoneNumber { get; private set; }
        public string? Address { get; private set; }
        public CustomerTier Tier { get; private set; } = CustomerTier.Standard;
        public bool IsActive { get; private set; } = true;

        // Navigation
        public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
    }
}
