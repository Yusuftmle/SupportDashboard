using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.AIPromptTemplate;
using MediatR;

namespace Application.Queries.AIPromptTemplates
{
    public class GetAllAIPromptTemplatesQueryHandler : IRequestHandler<GetAllAIPromptTemplatesQuery, List<AIPromptTemplateDto>>
    {
        private readonly IAIPromptTemplateRepository _repository;

        public GetAllAIPromptTemplatesQueryHandler(IAIPromptTemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AIPromptTemplateDto>> Handle(GetAllAIPromptTemplatesQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.AsQueryable()
                .AsNoTracking()
                .Where(pt => !pt.IsDeleted);

            if (!string.IsNullOrEmpty(request.Category))
                query = query.Where(pt => pt.Category == request.Category);

            if (request.IsActive.HasValue)
                query = query.Where(pt => pt.IsActive == request.IsActive.Value);

            var result = await query
                .OrderBy(pt => pt.Name)
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
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
