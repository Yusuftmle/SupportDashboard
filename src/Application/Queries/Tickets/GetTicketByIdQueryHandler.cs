using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Tickets
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto?>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByIdQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketDto?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _ticketRepository.AsQueryable()
                .AsNoTracking()
                .Where(t => t.Id == request.Id && !t.IsDeleted)
                .Select(t => new TicketDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status.ToString(),
                    Priority = t.Priority.ToString(),
                    CreatedById = t.CreatedById,
                    AssignedToId = t.AssignedToId,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    ResolutionNotes = t.ResolutionNotes,
                    ResolvedDate = t.ResolvedDate,
                    DueDate = t.DueDate,
                    Category = t.Category,
                    CustomerSatisfactionRating = t.CustomerSatisfactionRating,
                    AIGeneratedSummary = t.AIGeneratedSummary,
                    SentimentScore = t.SentimentScore,
                    UrgencyScoreAI = t.UrgencyScoreAI,
                    SuggestedCategory = t.SuggestedCategory,
                    AIConfidenceLevel = t.AIConfidenceLevel,
                    CreateDate = t.CreateDate,
                    CreatedByName = t.CreatedBy != null ? t.CreatedBy.FullName : "",
                    AssignedToName = t.AssignedTo != null ? t.AssignedTo.FullName : null
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
