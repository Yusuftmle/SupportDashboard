using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Tickets
{
    public class GetTicketStatsQueryHandler : IRequestHandler<GetTicketStatsQuery, TicketStatsDto>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketStatsQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketStatsDto> Handle(GetTicketStatsQuery request, CancellationToken cancellationToken)
        {
            var query = _ticketRepository.AsQueryable()
                .AsNoTracking()
                .Where(t => !t.IsDeleted);

            if (request.UserId.HasValue)
                query = query.Where(t => t.CreatedById == request.UserId || t.AssignedToId == request.UserId);

            if (request.StartDate.HasValue)
                query = query.Where(t => t.CreatedAt >= request.StartDate);

            if (request.EndDate.HasValue)
                query = query.Where(t => t.CreatedAt <= request.EndDate);

            var tickets = await query.ToListAsync(cancellationToken);
            var now = DateTime.UtcNow;

            var stats = new TicketStatsDto
            {
                TotalTickets = tickets.Count,
                OpenTickets = tickets.Count(t => t.Status == TicketStatus.Open),
                InProgressTickets = tickets.Count(t => t.Status == TicketStatus.InProgress),
                ClosedTickets = tickets.Count(t => t.Status == TicketStatus.Closed),
                OverdueTickets = tickets.Count(t => t.DueDate.HasValue && t.DueDate < now && t.Status != TicketStatus.Closed)
            };

            // Calculate average resolution time
            var resolvedTickets = tickets.Where(t => t.ResolvedDate.HasValue).ToList();
            if (resolvedTickets.Any())
            {
                var totalResolutionTime = resolvedTickets
                    .Sum(t => (t.ResolvedDate!.Value - t.CreatedAt).TotalHours);
                stats.AverageResolutionTimeHours = totalResolutionTime / resolvedTickets.Count;
            }

            // Calculate average satisfaction rating
            var ratedTickets = tickets.Where(t => t.CustomerSatisfactionRating.HasValue).ToList();
            if (ratedTickets.Any())
            {
                stats.AverageSatisfactionRating = (decimal)ratedTickets
                    .Average(t => t.CustomerSatisfactionRating!.Value);
            }

            return stats;
        }
    }
}
