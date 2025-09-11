using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.TicketComment
{
    public class DeleteTicketCommentCommandHandler : IRequestHandler<DeleteTicketCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTicketCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.TicketCommentRepository.GetByIdAsync(request.Id);
            if (comment == null || comment.IsDeleted) return false;

            // Soft delete
            comment.IsDeleted = true;
            _unitOfWork.TicketCommentRepository.Update(comment);

            // Create ticket event
            var ticketEvent = new TicketEvent(
                comment.TicketId,
                TicketEventType.CommentDeleted,
                "Comment deleted"
            );
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
