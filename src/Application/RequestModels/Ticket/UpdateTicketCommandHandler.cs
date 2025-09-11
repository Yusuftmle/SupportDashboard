using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Id);
            if (ticket == null || ticket.IsDeleted) return false;

            var hasChanges = false;

            // Track changes for events
            var oldValues = new Dictionary<string, string?>();
            var newValues = new Dictionary<string, string?>();

            if (!string.IsNullOrEmpty(request.Ticket.Title))
            {
                oldValues["Title"] = ticket.Title;
                ticket.GetType().GetProperty("Title")?.SetValue(ticket, request.Ticket.Title);
                newValues["Title"] = request.Ticket.Title;
                hasChanges = true;
            }

            if (!string.IsNullOrEmpty(request.Ticket.Status) &&
                Enum.TryParse<TicketStatus>(request.Ticket.Status, out var status))
            {
                oldValues["Status"] = ticket.Status.ToString();
                ticket.GetType().GetProperty("Status")?.SetValue(ticket, status);
                newValues["Status"] = status.ToString();
                hasChanges = true;
            }

            if (!string.IsNullOrEmpty(request.Ticket.Priority) &&
                Enum.TryParse<PriorityStatus>(request.Ticket.Priority, out var priority))
            {
                oldValues["Priority"] = ticket.Priority.ToString();
                ticket.GetType().GetProperty("Priority")?.SetValue(ticket, priority);
                newValues["Priority"] = priority.ToString();
                hasChanges = true;
            }

            if (request.Ticket.AssignedToId.HasValue)
            {
                oldValues["AssignedTo"] = ticket.AssignedToId?.ToString();
                ticket.AssignTo(request.Ticket.AssignedToId.Value);
                newValues["AssignedTo"] = request.Ticket.AssignedToId.ToString();
                hasChanges = true;
            }

            if (!string.IsNullOrEmpty(request.Ticket.ResolutionNotes))
            {
                ticket.GetType().GetProperty("ResolutionNotes")?.SetValue(ticket, request.Ticket.ResolutionNotes);
                hasChanges = true;
            }

            if (hasChanges)
            {
                _unitOfWork.TicketRepository.Update(ticket);
                await _unitOfWork.CommitAsync(cancellationToken);

                // Create update event
                var eventData = string.Join(", ",
                    oldValues.Select(kv => $"{kv.Key}: {kv.Value} → {newValues.GetValueOrDefault(kv.Key)}"));

                var ticketEvent = new TicketEvent(ticket.Id, TicketEventType.Updated, eventData);
                await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);
                await _unitOfWork.CommitAsync(cancellationToken);
            }

            return hasChanges;
        }
    }
}
