using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.ConversationHistory
{
    public class CreateConversationHistoryCommandHandler : IRequestHandler<CreateConversationHistoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateConversationHistoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateConversationHistoryCommand request, CancellationToken cancellationToken)
        {
            var history = new ConversationHistory(
                request.History.SessionId,
                request.History.Message,
                request.History.IsFromUser
            );

            if (request.History.UserId.HasValue)
                history.SetUser(request.History.UserId.Value);

            if (request.History.TokenCount.HasValue)
                history.SetTokenCount(request.History.TokenCount.Value);

            if (!string.IsNullOrEmpty(request.History.PluginUsed))
                history.SetPluginUsed(request.History.PluginUsed);

            await _unitOfWork.ConversationHistoryRepository.AddAsync(history);
            await _unitOfWork.CommitAsync(cancellationToken);

            return history.Id;
        }
    }
}
