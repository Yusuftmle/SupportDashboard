using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AIPromptTemplate
{
    public class UpdateAIPromptTemplateDto
    {
        public string Template { get; set; } = string.Empty;
        public string? Parameters { get; set; }
        public bool? IsActive { get; set; }
    }
}
