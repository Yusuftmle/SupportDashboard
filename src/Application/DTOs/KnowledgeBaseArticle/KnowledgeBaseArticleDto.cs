using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.KnowledgeBaseArticle
{
    public class KnowledgeBaseArticleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DefaultPriority { get; set; } = string.Empty;
        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; } // Navigation
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
