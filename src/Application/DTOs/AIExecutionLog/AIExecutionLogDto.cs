using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AIExecutionLog
{
    public class AIExecutionLogDto
    {
        public Guid Id { get; set; }
        public Guid? TicketId { get; set; }
        public string WorkflowName { get; set; } = string.Empty;
        public string? StepName { get; set; }
        public string? InputData { get; set; }
        public string? OutputData { get; set; }
        public int ExecutionTimeMs { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
        public DateTime CreateDate { get; set; }
        public string? TicketTitle { get; set; } // Navigation
    }
}
