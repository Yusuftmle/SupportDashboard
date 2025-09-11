using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.AIPromptTemplate;
using MediatR;

namespace Application.Queries.AIPromptTemplates
{
    public class GetAIPromptTemplateByIdQueryHandler : IRequestHandler<GetAIPromptTemplateByIdQuery, AIPromptTemplateDto?>
    {
        private readonly IAIPromptTemplateRepository _repository;

        public GetAIPromptTemplateByIdQueryHandler(IAIPromptTemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<AIPromptTemplateDto?> Handle(GetAIPromptTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.AsQueryable()
                .AsNoTracking()
                .Where(pt => pt.Id == request.Id && !pt.IsDeleted)
                .Select(pt => new AIPromptTemplateDto
                {
                    Id = pt.Id,
                    Name = pt.Name,
                    Template = pt.Template,
                    Category = pt.Category,
                    Parameters = pt.Parameters,
                    IsActive = pt.IsActive,
                    CreateDate = pt.CreateDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
