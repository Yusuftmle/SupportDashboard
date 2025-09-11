using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.AssignTicket
{
    public class CloseTicketCommandHandler : IRequestHandler<CloseTicketCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CloseTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CloseTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Id);
            if (ticket == null || ticket.IsDeleted) return false;

            ticket.Close();

            if (!string.IsNullOrEmpty(request.ResolutionNotes))
                ticket.GetType().GetProperty("ResolutionNotes")?.SetValue(ticket, request.ResolutionNotes);

            if (request.SatisfactionRating.HasValue)
                ticket.GetType().GetProperty("CustomerSatisfactionRating")?.SetValue(ticket, request.SatisfactionRating);

            ticket.GetType().GetProperty("ResolvedDate")?.SetValue(ticket, DateTime.UtcNow);

            _unitOfWork.TicketRepository.Update(ticket);

            // Create closure event
            var ticketEvent = new TicketEvent(ticket.Id, TicketEventType.Closed, "Ticket closed");
            if (!string.IsNullOrEmpty(request.ResolutionNotes))
                ticketEvent.SetComment(request.ResolutionNotes);

            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
