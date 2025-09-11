using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.ConversationHistory
{
    public class DeleteConversationHistoryCommandHandler : IRequestHandler<DeleteConversationHistoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConversationHistoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteConversationHistoryCommand request, CancellationToken cancellationToken)
        {
            var histories = await _unitOfWork.ConversationHistoryRepository.AsQueryable()
                .Where(h => h.SessionId == request.SessionId && !h.IsDeleted)
                .ToListAsync(cancellationToken);

            if (!histories.Any()) return false;

            foreach (var history in histories)
            {
                history.IsDeleted = true;
                _unitOfWork.ConversationHistoryRepository.Update(history);
            }

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
