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
    public class CreateTicketAttachmentCommandHandler : IRequestHandler<CreateTicketAttachmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketAttachmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketAttachmentCommand request, CancellationToken cancellationToken)
        {
            // Verify ticket exists
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Attachment.TicketId);
            if (ticket == null || ticket.IsDeleted)
                throw new ArgumentException("Ticket not found");

            var attachment = new TicketAttachment();

            // Set properties via reflection
            var properties = typeof(TicketAttachment).GetProperties();
            properties.FirstOrDefault(p => p.Name == "TicketId")?.SetValue(attachment, request.Attachment.TicketId);
            properties.FirstOrDefault(p => p.Name == "CommentId")?.SetValue(attachment, request.Attachment.CommentId);
            properties.FirstOrDefault(p => p.Name == "FileName")?.SetValue(attachment, request.Attachment.FileName);
            properties.FirstOrDefault(p => p.Name == "FilePath")?.SetValue(attachment, request.Attachment.FilePath);
            properties.FirstOrDefault(p => p.Name == "FileSize")?.SetValue(attachment, request.Attachment.FileSize);
            properties.FirstOrDefault(p => p.Name == "ContentType")?.SetValue(attachment, request.Attachment.ContentType);
            properties.FirstOrDefault(p => p.Name == "UploadedById")?.SetValue(attachment, request.Attachment.UploadedById);

            await _unitOfWork.TicketAttachmentRepository.AddAsync(attachment);

            // Create ticket event
            var ticketEvent = new TicketEvent(
                request.Attachment.TicketId,
                TicketEventType.AttachmentAdded,
                $"Attachment added: {request.Attachment.FileName}"
            );
            ticketEvent.SetUser(request.Attachment.UploadedById);
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return attachment.Id;
        }
    }
}
