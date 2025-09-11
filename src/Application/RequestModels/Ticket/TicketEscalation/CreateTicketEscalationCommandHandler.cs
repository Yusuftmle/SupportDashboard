using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.TicketEscalation
{
    public class CreateTicketEscalationCommandHandler : IRequestHandler<CreateTicketEscalationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketEscalationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketEscalationCommand request, CancellationToken cancellationToken)
        {
            // Verify ticket exists
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Escalation.TicketId);
            if (ticket == null || ticket.IsDeleted)
                throw new ArgumentException("Ticket not found");

            var escalation = new TicketEscalation();

            var properties = typeof(TicketEscalation).GetProperties();
            properties.FirstOrDefault(p => p.Name == "TicketId")?.SetValue(escalation, request.Escalation.TicketId);
            properties.FirstOrDefault(p => p.Name == "FromUserId")?.SetValue(escalation, request.Escalation.FromUserId);
            properties.FirstOrDefault(p => p.Name == "ToUserId")?.SetValue(escalation, request.Escalation.ToUserId);
            properties.FirstOrDefault(p => p.Name == "Reason")?.SetValue(escalation, request.Escalation.Reason);
            properties.FirstOrDefault(p => p.Name == "EscalatedDate")?.SetValue(escalation, DateTime.UtcNow);

            if (Enum.TryParse<EscalationType>(request.Escalation.Type, out var escalationType))
                properties.FirstOrDefault(p => p.Name == "Type")?.SetValue(escalation, escalationType);

            await _unitOfWork.TicketEscalationRepository.AddAsync(escalation);

            // Update ticket assignment
            ticket.AssignTo(request.Escalation.ToUserId);
            _unitOfWork.TicketRepository.Update(ticket);

            // Create ticket event
            var ticketEvent = new TicketEvent(
                request.Escalation.TicketId,
                TicketEventType.Escalated,
                $"Ticket escalated: {request.Escalation.Reason}"
            );
            ticketEvent.SetUser(request.Escalation.FromUserId);
            ticketEvent.SetValueChange(
                request.Escalation.FromUserId.ToString(),
                request.Escalation.ToUserId.ToString()
            );
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return escalation.Id;
        }
    }
}
