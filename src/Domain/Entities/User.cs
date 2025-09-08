using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
       public string FullName { get; private set; } = string.Empty;
       public string Email { get; private set; } = string.Empty;
        public string? PhoneNumber { get; private set; }
        public string? Department { get; private set; }
        public DateTime? LastLoginDate { get; private set; }
        public UserRole Role { get; private set; }

        // Navigation
        public ICollection<Ticket> TicketsCreated { get; private set; } = new List<Ticket>();
        public ICollection<Ticket> TicketsAssigned { get; private set; } = new List<Ticket>();
        public void UpdateProfile(string? phoneNumber, string? department)
        {
            PhoneNumber = phoneNumber;
            Department = department;
        }

        public void UpdateLastLogin()
        {
            LastLoginDate = DateTime.UtcNow;
        }

        public void SetActiveStatus(bool isActive)
        {
            IsActive = isActive;
        }
        public User(string fullName, string email, UserRole role)
        {
            FullName = fullName;
            Email = email;
            Role = role;
        }
        .
        public void UpdateRole(UserRole role)
        {
            Role = role;
        }
    }
}
