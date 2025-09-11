using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public int CreatedTicketsCount { get; set; } // Navigation count
        public int AssignedTicketsCount { get; set; } // Navigation count
    }
}
