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
    public class CreateTicketCommentCommandHandler : IRequestHandler<CreateTicketCommentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketCommentCommand request, CancellationToken cancellationToken)
        {
            // First verify ticket exists
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Comment.TicketId);
            if (ticket == null || ticket.IsDeleted)
                throw new ArgumentException("Ticket not found");

            var comment = new TicketComment();

            // Set properties via reflection since they have private setters
            var properties = typeof(TicketComment).GetProperties();
            properties.FirstOrDefault(p => p.Name == "TicketId")?.SetValue(comment, request.Comment.TicketId);
            properties.FirstOrDefault(p => p.Name == "UserId")?.SetValue(comment, request.Comment.UserId);
            properties.FirstOrDefault(p => p.Name == "Content")?.SetValue(comment, request.Comment.Content);
            properties.FirstOrDefault(p => p.Name == "IsInternal")?.SetValue(comment, request.Comment.IsInternal);
            properties.FirstOrDefault(p => p.Name == "IsPublic")?.SetValue(comment, request.Comment.IsPublic);

            await _unitOfWork.TicketCommentRepository.AddAsync(comment);

            // Create ticket event for new comment
            var ticketEvent = new TicketEvent(
                request.Comment.TicketId,
                TicketEventType.CommentAdded,
                request.Comment.IsInternal ? "Internal comment added" : "Comment added"
            );
            ticketEvent.SetUser(request.Comment.UserId);
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return comment.Id;
        }
    }
}
