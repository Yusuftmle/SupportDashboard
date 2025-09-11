using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.AIPromptTemplate
{
    public class DeleteAIPromptTemplateCommandHandler : IRequestHandler<DeleteAIPromptTemplateCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAIPromptTemplateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAIPromptTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = await _unitOfWork.AIPromptTemplateRepository.GetByIdAsync(request.Id);
            if (template == null || template.IsDeleted) return false;

            // Soft delete
            template.IsDeleted = true;
            _unitOfWork.AIPromptTemplateRepository.Update(template);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
