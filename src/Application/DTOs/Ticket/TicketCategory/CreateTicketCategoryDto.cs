using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketCategory
{
    public class CreateTicketCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? DepartmentId { get; set; }
        public int EstimatedResolutionHours { get; set; } = 24;
    }
}
