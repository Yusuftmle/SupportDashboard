using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.AIPromptTemplate
{
    public class UpdateAIPromptTemplateCommandHandler : IRequestHandler<UpdateAIPromptTemplateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAIPromptTemplateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateAIPromptTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = await _unitOfWork.AIPromptTemplateRepository.GetByIdAsync(request.Id);
            if (template == null || template.IsDeleted) return false;

            template.UpdateTemplate(request.Template.Template);

            if (!string.IsNullOrEmpty(request.Template.Parameters))
                template.SetParameters(request.Template.Parameters);

            if (request.Template.IsActive.HasValue)
            {
                if (request.Template.IsActive.Value)
                    template.Activate();
                else
                    template.Deactivate();
            }

            _unitOfWork.AIPromptTemplateRepository.Update(template);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
