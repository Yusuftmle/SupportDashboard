using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketComment
{
    public class TicketCommentDto
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsInternal { get; set; }
        public bool IsPublic { get; set; }
        public bool IsAIGenerated { get; set; }
        public decimal? SentimentScore { get; set; }
        public string? IntentClassification { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserFullName { get; set; } = string.Empty; // Navigation
        public string TicketTitle { get; set; } = string.Empty; // Navigation
    }
}
