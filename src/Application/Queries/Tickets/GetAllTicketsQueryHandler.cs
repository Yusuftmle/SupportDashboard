using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Queries.Tickets
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, List<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetAllTicketsQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var query = _ticketRepository.AsQueryable()
                .AsNoTracking()
                .Where(t => !t.IsDeleted);

            // Apply filters
            if (!string.IsNullOrEmpty(request.Status) && Enum.TryParse<TicketStatus>(request.Status, out var status))
                query = query.Where(t => t.Status == status);

            if (!string.IsNullOrEmpty(request.Priority) && Enum.TryParse<PriorityStatus>(request.Priority, out var priority))
                query = query.Where(t => t.Priority == priority);

            if (request.AssignedToId.HasValue)
                query = query.Where(t => t.AssignedToId == request.AssignedToId);

            if (request.CreatedById.HasValue)
                query = query.Where(t => t.CreatedById == request.CreatedById);

            if (request.StartDate.HasValue)
                query = query.Where(t => t.CreatedAt >= request.StartDate);

            if (request.EndDate.HasValue)
                query = query.Where(t => t.CreatedAt <= request.EndDate);

            // Pagination
            var skip = (request.Page - 1) * request.PageSize;

            var result = await query
                .OrderByDescending(t => t.CreatedAt)
                .Skip(skip)
                .Take(request.PageSize)
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
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
