using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketCategory
{
    public class TicketCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public int EstimatedResolutionHours { get; set; }
        public DateTime CreateDate { get; set; }
        public string? DepartmentName { get; set; } // Navigation
        public int TicketCount { get; set; } // Navigation 
    }
}
