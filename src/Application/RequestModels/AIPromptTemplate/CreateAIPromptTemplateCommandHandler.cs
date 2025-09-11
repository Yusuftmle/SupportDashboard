using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.AIPromptTemplate
{
    public class CreateAIPromptTemplateCommandHandler : IRequestHandler<CreateAIPromptTemplateCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAIPromptTemplateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateAIPromptTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = new AIPromptTemplate(
                request.Template.Name,
                request.Template.Template,
                request.Template.Category
            );

            if (!string.IsNullOrEmpty(request.Template.Parameters))
                template.SetParameters(request.Template.Parameters);

            await _unitOfWork.AIPromptTemplateRepository.AddAsync(template);
            await _unitOfWork.CommitAsync(cancellationToken);

            return template.Id;
        }
    }
}
