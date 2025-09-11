using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ConversationHistory
{
    public class ConversationHistoryDto
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid? UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsFromUser { get; set; }
        public int? TokenCount { get; set; }
        public string? PluginUsed { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UserFullName { get; set; } // Navigation
    }
}
