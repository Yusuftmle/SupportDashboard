using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket
{
    public class UpdateTicketDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public Guid? AssignedToId { get; set; }
        public string? ResolutionNotes { get; set; }
        public string? Category { get; set; }
        public DateTime? DueDate { get; set; }
        public int? CustomerSatisfactionRating { get; set; }
    }
}
