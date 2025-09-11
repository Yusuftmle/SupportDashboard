using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.AIPromptTemplate
{
    public class DeleteAIPromptTemplateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
