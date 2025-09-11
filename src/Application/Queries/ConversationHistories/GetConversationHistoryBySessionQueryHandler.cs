using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ConversationHistory;
using MediatR;

namespace Application.Queries.ConversationHistories
{
    public class GetConversationHistoryBySessionQueryHandler : IRequestHandler<GetConversationHistoryBySessionQuery, List<ConversationHistoryDto>>
    {
        private readonly IConversationHistoryRepository _repository;

        public GetConversationHistoryBySessionQueryHandler(IConversationHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ConversationHistoryDto>> Handle(GetConversationHistoryBySessionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.AsQueryable()
                .AsNoTracking()
                .Where(h => h.SessionId == request.SessionId && !h.IsDeleted)
                .OrderBy(h => h.CreateDate)
                .Select(h => new ConversationHistoryDto
                {
                    Id = h.Id,
                    SessionId = h.SessionId,
                    UserId = h.UserId,
                    Message = h.Message,
                    IsFromUser = h.IsFromUser,
                    TokenCount = h.TokenCount,
                    PluginUsed = h.PluginUsed,
                    CreateDate = h.CreateDate,
                    UserFullName = h.User != null ? h.User.FullName : null
                })
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
