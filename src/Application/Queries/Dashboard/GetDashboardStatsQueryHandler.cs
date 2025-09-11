using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Dashboard
{
    public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery, DashboardStatsDto>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;

        public GetDashboardStatsQueryHandler(
            ITicketRepository ticketRepository,
            IUserRepository userRepository,
            ICustomerRepository customerRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
        }

        public async Task<DashboardStatsDto> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
        {
            var ticketQuery = _ticketRepository.AsQueryable()
                .AsNoTracking()
                .Where(t => !t.IsDeleted);

            if (request.UserId.HasValue)
                ticketQuery = ticketQuery.Where(t => t.CreatedById == request.UserId || t.AssignedToId == request.UserId);

            if (request.StartDate.HasValue)
                ticketQuery = ticketQuery.Where(t => t.CreatedAt >= request.StartDate);

            if (request.EndDate.HasValue)
                ticketQuery = ticketQuery.Where(t => t.CreatedAt <= request.EndDate);

            var tickets = await ticketQuery.ToListAsync(cancellationToken);
            var now = DateTime.UtcNow;

            // Basic stats
            var stats = new DashboardStatsDto
            {
                TotalTickets = tickets.Count,
                OpenTickets = tickets.Count(t => t.Status == TicketStatus.Open),
                InProgressTickets = tickets.Count(t => t.Status == TicketStatus.InProgress),
                ClosedTickets = tickets.Count(t => t.Status == TicketStatus.Closed),
                OverdueTickets = tickets.Count(t => t.DueDate.HasValue && t.DueDate < now && t.Status != TicketStatus.Closed)
            };

            // User and customer stats
            stats.TotalUsers = await _userRepository.AsQueryable()
                .AsNoTracking()
                .CountAsync(u => !u.IsDeleted, cancellationToken);

            stats.TotalCustomers = await _customerRepository.AsQueryable()
                .AsNoTracking()
                .CountAsync(c => !c.IsDeleted, cancellationToken);

            stats.ActiveCustomers = await _customerRepository.AsQueryable()
                .AsNoTracking()
                .CountAsync(c => !c.IsDeleted && c.IsActive, cancellationToken);

            // Ticket trend (last 30 days)
            var thirtyDaysAgo = DateTime.UtcNow.Date.AddDays(-30);
            var dailyTickets = tickets
                .Where(t => t.CreatedAt >= thirtyDaysAgo)
                .GroupBy(t => t.CreatedAt.Date)
                .Select(g => new TicketsByDayDto
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToList();

            stats.TicketTrend = dailyTickets;

            // Tickets by status
            var totalTicketsCount = tickets.Count;
            if (totalTicketsCount > 0)
            {
                stats.TicketsByStatus = tickets
                    .GroupBy(t => t.Status)
                    .Select(g => new TicketStatusCountDto
                    {
                        Status = g.Key.ToString(),
                        Count = g.Count(),
                        Percentage = Math.Round((double)g.Count() / totalTicketsCount * 100, 2)
                    })
                    .ToList();

                // Tickets by priority
                stats.TicketsByPriority = tickets
                    .GroupBy(t => t.Priority)
                    .Select(g => new TicketPriorityCountDto
                    {
                        Priority = g.Key.ToString(),
                        Count = g.Count(),
                        Percentage = Math.Round((double)g.Count() / totalTicketsCount * 100, 2)
                    })
                    .ToList();
            }

            // Top agents (if not filtering by specific user)
            if (!request.UserId.HasValue)
            {
                var resolvedTickets = tickets.Where(t => t.Status == TicketStatus.Closed && t.AssignedToId.HasValue).ToList();

                stats.TopAgents = resolvedTickets
                    .GroupBy(t => new { t.AssignedToId, AssignedToName = t.AssignedTo?.FullName ?? "Unknown" })
                    .Select(g => new TopAgentDto
                    {
                        UserId = g.Key.AssignedToId!.Value,
                        UserName = g.Key.AssignedToName,
                        TicketsResolved = g.Count(),
                        AverageResolutionTimeHours = g.Where(t => t.ResolvedDate.HasValue)
                            .Average(t => (t.ResolvedDate!.Value - t.CreatedAt).TotalHours),
                        AverageSatisfactionRating = g.Where(t => t.CustomerSatisfactionRating.HasValue)
                            .Any() ? (decimal)g.Where(t => t.CustomerSatisfactionRating.HasValue)
                                .Average(t => t.CustomerSatisfactionRating!.Value) : null
                    })
                    .OrderByDescending(a => a.TicketsResolved)
                    .Take(5)
                    .ToList();
            }

            return stats;
        }
    }
}
// ============= ADDITIONAL OPTIMIZED QUERY HANDLERS =============
// Remaining query handlers would follow similar patterns with:
// 1. AsNoTracking() for read-only operations
// 2. Proper WHERE clauses with IsDeleted checks first for index usage
// 3. Select projections to DTOs to avoid loading entire entities
// 4. Optimized joins using navigation properties
// 5. Pagination where appropriate
// 6. Proper ordering for consistent results