using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket.TicketComment;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Tickets.TicketComments
{
    public class GetTicketCommentsByTicketQueryHandler : IRequestHandler<GetTicketCommentsByTicketQuery, List<TicketCommentDto>>
    {
        private readonly ITicketCommentRepository _repository;

        public GetTicketCommentsByTicketQueryHandler(ITicketCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TicketCommentDto>> Handle(GetTicketCommentsByTicketQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.AsQueryable()
                .AsNoTracking()
                .Where(c => c.TicketId == request.TicketId && !c.IsDeleted);

            if (!request.IncludeInternal)
                query = query.Where(c => !c.IsInternal);

            var result = await query
                .OrderBy(c => c.CreateDate)
                .Select(c => new TicketCommentDto
                {
                    Id = c.Id,
                    TicketId = c.TicketId,
                    UserId = c.UserId,
                    Content = c.Content,
                    IsInternal = c.IsInternal,
                    IsPublic = c.IsPublic,
                    IsAIGenerated = c.IsAIGenerated,
                    SentimentScore = c.SentimentScore,
                    IntentClassification = c.IntentClassification,
                    CreateDate = c.CreateDate,
                    UserFullName = c.User.FullName,
                    TicketTitle = c.Ticket.Title
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
