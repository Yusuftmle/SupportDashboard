using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Customer
{
    public class CreateCustomerDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string Tier { get; set; } = "Standard";
    }
}
