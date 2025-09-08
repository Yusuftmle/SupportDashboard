using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class KnowledgeBaseArticle : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Subject { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public PriorityStatus DefaultPriority { get; private set; }
        public Guid? CategoryId { get; private set; }
        public bool IsActive { get; private set; } = true;

        // Navigation
        public TicketCategory? Category { get; private set; }
    }
}
