using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Customer
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Tier { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int TicketCount { get; set; } // Navigation count
    }
}
