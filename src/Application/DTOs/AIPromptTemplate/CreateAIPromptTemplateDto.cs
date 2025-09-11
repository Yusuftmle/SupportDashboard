using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AIPromptTemplate
{
    public class CreateAIPromptTemplateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Parameters { get; set; }
    }
}
