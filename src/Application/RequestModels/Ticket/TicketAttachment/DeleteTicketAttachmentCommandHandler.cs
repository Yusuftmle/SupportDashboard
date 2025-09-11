using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.TicketAttachment
{
    public class DeleteTicketAttachmentCommandHandler : IRequestHandler<DeleteTicketAttachmentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketAttachmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _unitOfWork.TicketAttachmentRepository.GetByIdAsync(request.Id);
            if (attachment == null || attachment.IsDeleted) return false;

            // Soft delete
            attachment.IsDeleted = true;
            _unitOfWork.TicketAttachmentRepository.Update(attachment);

            // Create ticket event
            var ticketEvent = new TicketEvent(
                attachment.TicketId,
                TicketEventType.AttachmentDeleted,
                $"Attachment deleted: {attachment.FileName}"
            );
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
