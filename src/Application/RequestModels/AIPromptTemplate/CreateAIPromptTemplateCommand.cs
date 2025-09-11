using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.AIPromptTemplate;
using MediatR;

namespace Application.RequestModels.AIPromptTemplate
{
    public class CreateAIPromptTemplateCommand : IRequest<Guid>
    {
        public CreateAIPromptTemplateDto Template { get; set; }
    }
}
