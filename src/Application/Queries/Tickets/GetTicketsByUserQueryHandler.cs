using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Tickets
{
    public class GetTicketsByUserQueryHandler : IRequestHandler<GetTicketsByUserQuery, List<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsByUserQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketDto>> Handle(GetTicketsByUserQuery request, CancellationToken cancellationToken)
        {
            var query = _ticketRepository.AsQueryable()
                .AsNoTracking()
                .Where(t => !t.IsDeleted);

            if (request.IsCreatedBy)
                query = query.Where(t => t.CreatedById == request.UserId);
            else
                query = query.Where(t => t.AssignedToId == request.UserId);

            if (!string.IsNullOrEmpty(request.Status) && Enum.TryParse<TicketStatus>(request.Status, out var status))
                query = query.Where(t => t.Status == status);

            var result = await query
                .OrderByDescending(t => t.CreatedAt)
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
                    DueDate = t.DueDate,
                    Category = t.Category,
                    CreateDate = t.CreateDate,
                    CreatedByName = t.CreatedBy != null ? t.CreatedBy.FullName : "",
                    AssignedToName = t.AssignedTo != null ? t.AssignedTo.FullName : null
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
