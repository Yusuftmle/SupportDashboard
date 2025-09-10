using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AIPromptTemplate: BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Template { get; private set; } = string.Empty;
        public string? Category { get; private set; }
        public string? Parameters { get; private set; } // JSON
        public bool IsActive { get; private set; } = true;

        private AIPromptTemplate() { }

        // Public constructor
        public AIPromptTemplate(string name, string template, string? category = null)
        {
            Name = name;
            Template = template;
            Category = category;
        }

        public void UpdateTemplate(string template)
        {
            Template = template;
        }

        public void SetParameters(string parameters)
        {
            Parameters = parameters;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
